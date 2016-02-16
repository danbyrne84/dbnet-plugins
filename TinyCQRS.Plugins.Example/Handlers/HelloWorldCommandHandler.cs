using TinyCQRS.Core.Model.Handlers;
using TinyCQRS.Plugins.Example.Datastore;
using TinyCQRS.Plugins.Example.ExecutionUnits;

namespace TinyCQRS.Plugins.Example.Handlers
{
    public class HelloWorldCommandHandler : CommandHandler<HelloWorldCommand>
    {
        private readonly MemoryDataStore _dataStore = new MemoryDataStore();

        public override bool Handle(HelloWorldCommand command)
        {
            _dataStore.Store[command.UserId] = command.Name;  

            return true;
        }
    }
}
