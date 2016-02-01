using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Model;
using DBNet.Plugins.Registration;
using Newtonsoft.Json;

namespace DBNet.Plugins.Management
{
    public class PluginManager : IPluginManager
    {
        private readonly IPluginRegistrationFactory _registrationFactory;
        public List<IPlugin> Plugins { get; set; }

        public PluginManager()
        {
            _registrationFactory = new PluginRegistrationFactory();
        }

        public List<IPlugin> LoadPlugins(string path, string name = null, bool recursive = true)
        {
            var plugins = new List<IPlugin>();

            // directory structure should be..
            // app base
            // .. plugins
            // .. .. example
            // .. .. .. plugin.json
            var recursiveOpt = recursive ? SearchOption.AllDirectories :SearchOption.TopDirectoryOnly;

            var directories = Directory.GetDirectories(path, "*", recursiveOpt)
                .Where(x => x.Equals(path) == false);

            Parallel.ForEach(directories, directory =>
            {
                // look for JSON
                var metaFile = string.Concat(directory, Path.DirectorySeparatorChar, $"{name ?? "plugin"}.json");
                var json = File.ReadAllText(metaFile);

                // parse JSON into a DTO
                var metaData = JsonConvert.DeserializeObject<PluginInformation>(json);

                var plugin = _registrationFactory.RegisterPlugin(directory, metaData);
                if (plugin != null) plugins.Add(plugin);
            });

            return plugins;
        }

        public void Execute(ICqrsObject action)
        {
            var plugin = ChoosePluginForAction(action);
            var response = plugin.Handle(action);
        }

        public IPlugin ChoosePluginForAction(ICqrsObject action)
        {
            var capable = Plugins.Where(plugin => plugin.CanHandle(action.GetType().FullName));

            // pretty dumb selection logic for now, pass in ranking preferences later
            return capable.FirstOrDefault();
        }
    }
}
