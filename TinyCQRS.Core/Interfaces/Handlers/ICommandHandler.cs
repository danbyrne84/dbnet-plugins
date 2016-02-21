using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface ICommandHandler <in T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
