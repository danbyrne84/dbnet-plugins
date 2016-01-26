namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface IHandler
    {
        string Name { get; set; }
        string Handles { get; set; }
        string HandlerType { get; set; }
    }
}