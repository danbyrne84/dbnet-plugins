using TinyCQRS.Core.Model;

namespace TinyCQRS.Core.Dto
{
    public class Plugin
    {
        public PluginMetadata MetaData { get; set; }
        public string[] Handlers { get; set; }
    }
}