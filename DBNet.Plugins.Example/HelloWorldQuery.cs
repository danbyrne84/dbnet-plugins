using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Example
{
    public class HelloWorldQuery : IQuery<HelloWorldQuery, HelloWorldQueryResult>
    {
        public int UserId { get; set; }
    }
}