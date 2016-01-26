using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DBNet.Plugins.Dto;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Model;

namespace DBNet.Plugins.Registration
{
    public class PluginRegistrationFactory : IPluginRegistrationFactory
    {
        public IPlugin RegisterPlugin(string path, IPluginInformation pluginMeta)
        {
            var entryPath = Path.Combine(path, pluginMeta.EntryPoint);

            // some sanity checks
            if (File.Exists(entryPath) == false)
                throw new FileNotFoundException("Entry point not found", entryPath);

            // determine loader type here (native assembly, or shell out)
            // @todo - add support for other languages via shell

            // default to native assembly
            var assembly = Assembly.LoadFile(entryPath);

            return RegisterAssembly(assembly, pluginMeta);
        }

        /** .NET Native Binary Support - validate an assembly and loads its plugin implementation **/
        private IPlugin RegisterAssembly(Assembly assembly, IPluginInformation pluginMeta)
        {
            IPlugin pluginInstance;

            var pluginType = assembly.GetTypes()?
                .FirstOrDefault(x => typeof(IPlugin).IsAssignableFrom(x) 
                    && x.IsClass);

            // must be a matching type within the assembly
            if (pluginType == null)
                throw new RegistrationException($"Plugin type implementing IPlugin not found within the assembly {assembly}");

            try
            {
                pluginInstance = (IPlugin) Activator.CreateInstance(pluginType);
                pluginInstance.MetaData = pluginMeta;
            }
            catch (Exception ex)
            {
                throw new RegistrationException($"Error registering plugin from assembly {assembly}", ex);
            }

            return pluginInstance;
        }
    }
}
