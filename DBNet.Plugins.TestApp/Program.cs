using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DBNet.Plugins.Management;
namespace DBNet.Plugins.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // craete an instance of a pluginmanager
            var manager = new PluginManager();

            // find plugin directory
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (exePath == null) { throw new ApplicationException("executable assembly path could not be determined"); }

            var pluginPath = Path.Combine(exePath, "plugins");
            if (Directory.Exists(pluginPath) == false) { throw new ApplicationException("plugin subdirectory not found"); }

            // load any plugins in the plugin directory
            var plugins = manager.LoadPlugins(pluginPath);
            if (plugins.Any() == false) { throw new ApplicationException($"no plugins found in assembly at ${exePath}"); }

            // initialize them, or check something about them in their manifest first
            plugins.ForEach(plugin =>
            {
                plugin.Initialize();

                var methods = plugin.GetExposedMethods().ToList();
                if (!methods.Any()) return;

                Console.WriteLine("Registered Handlers:");
                Console.WriteLine(string.Join(",", methods.Select(x => x.ToString()).ToArray()));
            });

            Console.ReadKey();
        }
    }
}
