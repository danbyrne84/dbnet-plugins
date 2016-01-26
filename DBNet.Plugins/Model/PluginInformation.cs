using DBNet.Plugins.Interfaces;

namespace DBNet.Plugins.Model
{
    public class PluginInformation : IPluginInformation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntryPoint { get; set; }
        public string[] Handlers { get; set; }
    }
}
