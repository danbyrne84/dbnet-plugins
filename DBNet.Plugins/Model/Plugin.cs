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
    public class Plugin : IPlugin
    {
        public IPluginInformation MetaData { get; set;  }

        private const string Unknown = "Unknown";
        private const string PluginDirectory = "plugins";

        private readonly ICqrsHandlerFactory _cqrsHandlerFactory;

        public Plugin(IPluginInformation metaData, ICqrsHandlerFactory factory = null)
        {
            MetaData = metaData;
            _cqrsHandlerFactory = factory ?? new CqrsHandlerFactory();
        }

        public Plugin()
        {
            Console.WriteLine("Construct {0}", GetType());
        }

        public void Initialize()
        {
            Console.WriteLine($"{GetType()} :: Initialize");
        }

        private IEnumerable<ICqrsObject> _cqrsCollection;
        public IEnumerable<ICqrsObject> CqrsCollection
        {
            get
            {
                if (_cqrsCollection != null) return _cqrsCollection;

                var pluginPath = Unknown;

                try
                {
                    pluginPath = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        PluginDirectory, 
                        MetaData.Name, 
                        MetaData.EntryPoint);

                    return _cqrsCollection = Assembly.LoadFile(pluginPath)
                        .DefinedTypes.ToList()
                        .Where(x => typeof (ICqrsObject).IsAssignableFrom(x))
                        .Select(Activator.CreateInstance)
                        .Cast<ICqrsObject>()
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw new PluginEntryPointMissingException($"The entry point {pluginPath} for plugin {MetaData.Name} cannot be found", ex);
                }
            }
        }

        public bool CanHandle(string cqrsIdentifier)
        {
            return CqrsCollection.Any(x => x.GetType().Name == cqrsIdentifier);
        }

        public ICqrsResponse Handle(ICqrsObject action)
        {
            return _cqrsHandlerFactory.Handle(action);
        }
    }
}
