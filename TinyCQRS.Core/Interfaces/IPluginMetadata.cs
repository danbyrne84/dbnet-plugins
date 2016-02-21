namespace TinyCQRS.Core.Interfaces
{
    public interface IPluginMetadata
    {
        string Name { get; set; }
        string Description { get; set; }
        string EntryPoint { get; set; }
        string[] Handlers { get; set; }
    }
}