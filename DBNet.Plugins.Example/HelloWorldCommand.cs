using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Example
{
    public class HelloWorldCommand : ICommand
    {
        public string Name { get; set; }
    }
}
