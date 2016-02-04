using DBNet.Plugins.Interfaces.Handlers;

namespace DBNet.Plugins.Model
{
    public class Handler : IHandler
    {
        public string Name { get; set; }
        public string Handles { get; set; }
        public string HandlerType { get; set; }
    }
}