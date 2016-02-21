using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface IHandler
    {
        string Name { get; }
        string Type { get; }
        string Description { get; }
        ActionType HandlerType { get; }

        bool CanHandle(IAction action);
    }
}