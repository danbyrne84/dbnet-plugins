using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DBNet.Plugins.Exceptions;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Model
{
    public abstract class Plugin : IPlugin
    {
        public IPluginInformation MetaData { get; set;  }

        public Plugin(IPluginInformation metaData)
        {
            MetaData = metaData;
        }

        protected Plugin()
        {
            Console.WriteLine("Construct {0}", GetType());
        }

        public void Initialize()
        {
            Console.WriteLine($"{GetType()} :: Initialize");
        }

        public IEnumerable<ICqrsObject> GetExposedMethods()
        {
            IList<ICqrsObject> cqrsTypes;
            string pluginPath = null;

            try
            {
                pluginPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), MetaData.EntryPoint);

                var pluginTypes = Assembly.LoadFile(pluginPath).DefinedTypes.ToList();

                cqrsTypes = pluginTypes.Where(x => typeof(ICqrsObject).IsAssignableFrom(x))
                    .Select(Activator.CreateInstance)
                    .Cast<ICqrsObject>()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new PluginEntryPointMissingException($"The entry point {pluginPath ?? "(unknown)"} does not exist", ex);
            }

            if (cqrsTypes.Any() == false) throw new NoHandlersFoundException();

            return cqrsTypes;
        }

        public abstract bool CanHandle(string strongName);

        public abstract ICqrsResponse Handle(ICqrsObject action);
    }
}
