using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Interfaces.Results;

namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        bool Handle(T command);
    }

    public interface ICommandHandler
    {
        string Name { get; }
        string Description { get; }
    }
}
