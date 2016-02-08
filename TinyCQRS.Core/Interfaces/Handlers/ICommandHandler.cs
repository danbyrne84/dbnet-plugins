using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface ICommandHandler <in T> : ICommandHandler where T : ICommand
    {
    }

    public interface ICommandHandler : IHandler
    {
    }
}
