using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DBNet.Plugins.Exceptions;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Interfaces.Handlers;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Model
{
    public class Plugin : IPlugin
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
            Console.WriteLine("Initialize {0}", GetType());
        }

        public IEnumerable<ICqrsObject> GetExposedMethods()
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
            var baseType = typeof(IHandler);

            var pluginFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), MetaData.EntryPoint);

            var pluginTypes = Assembly.LoadFile(pluginFilePath).DefinedTypes
                .ToList();

            var t = pluginTypes[1].GetInterfaces();

            var ints = pluginTypes.SelectMany(x => x.GetInterfaces());

            var objs = pluginTypes.Where(x => typeof (ICqrsObject).IsAssignableFrom(x));

            var ret = objs.Select(Activator.CreateInstance) as IEnumerable<ICqrsObject>;

            if (ret == null)
                throw new NoHandlersFoundException();

            return ret;
        }
    }
}
