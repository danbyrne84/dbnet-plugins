using DBNet.Plugins.Model;

namespace DBNet.Plugins.Dto
{
    public class Plugin
    {
        public PluginInformation MetaData { get; set; }
        public string[] Handlers { get; set; }
    }
}