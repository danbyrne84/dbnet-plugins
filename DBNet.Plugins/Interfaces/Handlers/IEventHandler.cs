using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface IEventHandler<T> : IEventHandler where T : IEvent
    {

    }

    public interface IEventHandler : IHandler
    {
        bool CanHandle(IEvent @event);
    }
}
