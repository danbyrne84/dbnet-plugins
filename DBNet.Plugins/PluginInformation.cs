namespace DBNet.Plugins
{
    public class PluginInformation : IPluginInformation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntryPoint { get; set; }
        public string[] Handlers { get; set; }
    }
    public interface IPluginInformation
    {
        string Name { get; set; }
        string Description { get; set; }
        string[] Handlers { get; set; }
        string EntryPoint { get; set; }
    }
}
