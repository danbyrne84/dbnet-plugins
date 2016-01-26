namespace DBNet.Plugins.Interfaces
{
    public interface IPluginInformation
    {
        string Name { get; set; }
        string Description { get; set; }
        string EntryPoint { get; set; }
        string[] Handlers { get; set; }
    }
}