using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinyCQRS.Core.Interfaces;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model;
using TinyCQRS.Core.Registration;

namespace TinyCQRS.Core.Management
{
    public class PluginManager : IPluginManager
    {
        private readonly IPluginRegistrationFactory _registrationFactory;
        public List<IPlugin> Plugins { get; set; }

        public PluginManager()
        {
            _registrationFactory = new PluginRegistrationFactory();
        }

        public List<IPlugin> LoadPlugins(string path, string name = null, bool recursive = false)
        {
            var plugins = new List<IPlugin>();

            // directory structure should be..
            // app base
            // .. plugins
            // .. .. example
            // .. .. .. plugin.json
            var recursiveOpt = recursive ? SearchOption.AllDirectories :SearchOption.TopDirectoryOnly;

            var directories = Directory.GetDirectories(path, "*", recursiveOpt);

            Parallel.ForEach(directories, directory =>
            {
                // look for JSON
                var metaFile = string.Concat(directory, Path.DirectorySeparatorChar, $"{name ?? "plugin"}.json");
                var json = File.ReadAllText(metaFile);

                // parse JSON into a DTO
                var metaData = JsonConvert.DeserializeObject<PluginMetadata>(json);

                var plugin = _registrationFactory.RegisterPlugin(directory, metaData);
                if (plugin != null) plugins.Add(plugin);
            });

            return plugins;
        }

        public void Execute(IAction action)
        {
            var plugin = ChoosePluginForAction(action);
            var response = plugin.Handle(action);
        }

        public IPlugin ChoosePluginForAction(IAction action)
        {
            var capable = Plugins.Where(plugin => plugin.CanHandle(action));

            // pretty dumb selection logic for now, pass in ranking preferences later
            return capable.FirstOrDefault();
        }
    }
}
