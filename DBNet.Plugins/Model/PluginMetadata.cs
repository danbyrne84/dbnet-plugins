using TinyCQRS.Core.Interfaces;

namespace TinyCQRS.Core.Model
{
    public class PluginMetadata : IPluginMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntryPoint { get; set; }
        public string[] Handlers { get; set; }
    }
}
