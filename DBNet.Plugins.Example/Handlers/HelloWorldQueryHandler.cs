using System.Linq;
using TinyCQRS.Core.Model.Handlers;
using TinyCQRS.Plugins.Example.Datastore;
using TinyCQRS.Plugins.Example.ExecutionUnits;

namespace TinyCQRS.Plugins.Example.Handlers
{
    public class HelloWorldQueryHandler : QueryHandler<HelloWorldQuery, HelloWorldQueryResult>
    {
        private readonly MemoryDataStore _datastore = new MemoryDataStore();
        private const string UnknownUser = "Unknown User";

        public override HelloWorldQueryResult Handle(HelloWorldQuery query)
        {
            return new HelloWorldQueryResult
            {
                UserName = (_datastore?.Store?
                    .First(x => x.Key == query.UserId)
                    .Value as string) ?? UnknownUser
            };
        }
    }

    public class HelloWorldQueryResult
    {
        public string UserName { get; set; }
    }
}
