using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Handlers;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Example
{
    public class HelloWorldCommandHandler : ICommandHandler, ICommandHandler<HelloWorldCommand>
    {
        public void Handle(HelloWorldCommand command)
        {
            Console.WriteLine($"Hello, {command.Name}!");
        }

        public string Name => "HelloWorldCommand";
        public string Description => "";
    }
}
