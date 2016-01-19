using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DBNet.Plugins
{
    public class Plugin : IPlugin, IHandlerProvider
    {
        public IPluginInformation MetaData { get; }
        public Plugin(IPluginInformation metaData)
        {
            MetaData = metaData;
        }
        public Plugin() { }
        public void Initialize() { }

        public IEnumerable<IHandler> Handlers
        {
            get
            {
                var instances = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableFrom(typeof (Handler)))
                    .Select(Activator.CreateInstance) as IEnumerable<Handler>;

                if (instances == null)
                    throw new NoHandlersFoundException();

                return instances.Where(x => MetaData.Handlers.Contains(x.Name));
            }
        }
    }

    public interface IHandlerProvider
    {
        IEnumerable<IHandler> Handlers { get; }
    }

    public interface IPlugin
    {
        void Initialize();
        IPluginInformation MetaData { get; }
        IEnumerable<IHandler> Handlers { get; }
    }
}
