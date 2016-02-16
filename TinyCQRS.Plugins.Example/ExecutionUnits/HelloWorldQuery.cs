using TinyCQRS.Core.Model.ExecutionUnits;
using TinyCQRS.Plugins.Example.Handlers;

namespace TinyCQRS.Plugins.Example.ExecutionUnits
{
    public class HelloWorldQuery : Query<HelloWorldQuery,HelloWorldQueryResult>
    {
        public int UserId { get; set; }
    }
}