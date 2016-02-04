using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Example.Datastore;
using DBNet.Plugins.Interfaces.Handlers;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Interfaces.Results;
using DBNet.Plugins.Model.Results;
using DBNet.Plugins.Model;

namespace DBNet.Plugins.Example
{
    public class HelloWorldCommandHandler : ICommandHandler<HelloWorldCommand>
    {
        private readonly MemoryDataStore _dataStore = new MemoryDataStore();

        public bool Handle(HelloWorldCommand command)
        {
            // store the name
            _dataStore.Store["name"] = command.Name;

            // return success
            return true;
        }

        public string Name => "HelloWorldCommand";
        public string Description => "";
    }
}
