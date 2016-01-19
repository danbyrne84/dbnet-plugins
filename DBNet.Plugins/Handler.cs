namespace DBNet.Plugins
{
    public class Handler : IHandler
    {
        public string Name { get; set; }
    }
    public interface IHandler
    {
        string Name { get; set; }
    }
}
