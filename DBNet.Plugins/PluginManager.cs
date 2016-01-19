using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DBNet.Plugins
{
    public class PluginManager : IPluginManager
    {
        private List<IPlugin> Plugins => new List<IPlugin>();
        public List<IPlugin> LoadPlugins(string path)
        {
            var files      = Directory.GetFiles(path, "*.dll");
            var assemblies = files.Select(Assembly.LoadFile);
            var plugins    = assemblies.Select(RegisterPlugin);

            return plugins.ToList();
        }

        public IPlugin RegisterPlugin(Assembly assembly)
        {
            var pluginType = assembly.GetTypes()?.FirstOrDefault(x => 
                typeof(IPlugin).IsAssignableFrom(x) && x.IsClass);

            if (pluginType == null)
                return null;

            var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);
            if (pluginInstance == null)
                return null;

            Plugins.Add(pluginInstance);
            return pluginInstance;
        }
    }

    public interface IPluginManager
    {
        List<IPlugin> LoadPlugins(string path);
        IPlugin RegisterPlugin(Assembly assembly);
    }
}
