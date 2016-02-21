using System.ComponentModel;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;
using TinyCQRS.Core.Model.Handlers;
using TinyCQRS.Core.Model.Results;
using TinyCQRS.Plugins.Example.Datastore;
using TinyCQRS.Plugins.Example.ExecutionUnits;

namespace TinyCQRS.Plugins.Example.Handlers
{
    public class HelloWorldCommandHandler : CommandHandler, ICommandHandler<HelloWorldCommand>
    {
        private readonly MemoryDataStore _dataStore = new MemoryDataStore();

        public HelloWorldCommandHandler()
        {
            
        }

        ICommandResult ICommandHandler<HelloWorldCommand>.Handle(HelloWorldCommand command)
        {
            _dataStore.Store[command.UserId] = command.Name;

            return new CommandResult(true);
        }
    }
}
