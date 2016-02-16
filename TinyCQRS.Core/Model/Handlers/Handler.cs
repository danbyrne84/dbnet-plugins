using System;
using System.Linq;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model.Handlers
{
    public abstract class Handler : IHandler
    {
        public string Name => GetType().Name;
        public string Type { get; set; }
        public string Description { get; set; }
        public bool CanHandle(IAction action)
        {
            // @todo & typeof is IHandler
            var interfaces = GetType().GetInterfaces();
            var candidates = interfaces.Where(x => x.IsConstructedGenericType 
                                                && x.GetGenericArguments()[0] == action.GetType());

            return candidates.Any();
        }

        public ICqrsResponse Handle(IAction action)
        {
            // find relevent type
            var classes = GetType().Assembly.GetTypes();

            var candidates = classes.Where(c => c.GetInterfaces().Any(i => i.gener));s

            var handlerType = candidates.FirstOrDefault();

            var concrete = classes.FirstOrDefault(x => x.IsGenericTypeDefinition && x.GetInterfaces().Any(i => i == handlerType));

            if (concrete == null) return new CqrsResponse();

            concrete = concrete.MakeGenericType(action.GetType());

            // instantiate (generic) and handle
            var instance = Activator.CreateInstance(concrete) as IHandler;

            return instance?.Handle(action) ?? new CqrsResponse();

        }
    }
}