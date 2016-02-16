using TinyCQRS.Core.Model.ExecutionUnits;

namespace TinyCQRS.Plugins.Example.ExecutionUnits
{
    public class HelloWorldCommand : Command
    {
        public int UserId { get; set; }
        public new string Name { get; set; }
    }
}
