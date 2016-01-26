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

        public IEnumerable<IHandler> GetHandlers()
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
            var baseType = typeof (IHandler);

            var pluginFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),MetaData.EntryPoint);

            var pluginTypes = Assembly.LoadFile(pluginFilePath).DefinedTypes
                .ToList();

            var ints = pluginTypes.SelectMany(x => x.GetInterfaces());

            var z = pluginTypes.Where(x => typeof (ICommand).IsAssignableFrom(x));
            

            var handlers =
                pluginTypes
                    .SelectMany(
                        x => x.GetInterfaces().Where(it =>
                            it.FullName.Contains("ICommand") ||
                            it.FullName.Contains("IQuery") ||
                            it.FullName.Contains("IEvent")));
                    //.Select(Activator.CreateInstance);

            var commands =
                pluginTypes
                    .Where(x => x.GetInterface("ICommand") != null)
                    .Select(Activator.CreateInstance);


            /**
            var handlerTypes = allTypes.Where(x => x.FullName.StartsWith("DBNet.Plugins")).Where(x => x.FindInterfaces(y => typeof(ICommandHandler<,>))); // {Name = "HelloWorldCommandHandler" FullName = "DBNet.Plugins.Example.HelloWorldCommandHandler"}
            var handler = allTypes.Where(x => x.FullName.StartsWith("DBNet.Plugins.Example.HelloWorldCommandHandler"));

            var instances = handlerTypes?.Select(Activator.CreateInstance) as IEnumerable<IHandler>;
            **/
            if (handlers == null)
                throw new NoHandlersFoundException();

            return null;
        }
    }
}
