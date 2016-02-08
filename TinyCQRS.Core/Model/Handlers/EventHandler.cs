using System.Linq;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Handlers
{
    public abstract class EventHandler : Handler, IEventHandler
    {
        public bool CanHandle(IEvent @event)
        {
            return GetType().Assembly.GetTypes()
                .Any(t => t.IsGenericType && typeof(IEvent).IsAssignableFrom(t));
        }
    }

    public abstract class EventHandler<T> : EventHandler, IEventHandler<T> where T : IEvent
    {
        public abstract void Handle(T evt);
    }
}
