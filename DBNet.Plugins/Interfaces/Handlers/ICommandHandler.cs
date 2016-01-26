using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }

    public interface ICommandHandler
    {
        string Name { get; }
        string Description { get; }
    }
}
