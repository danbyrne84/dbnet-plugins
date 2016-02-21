using System;
using System.Linq;
using System.Reflection;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model.Handlers
{
    public abstract class Handler : IHandler
    {
        public string Name => GetType().Name;

        public string Type
        {
            get { return GetType().Name; }
            set
            {
                
            }
        }

        public string Description { get; set; }
        public abstract ActionType HandlerType { get; }

        public bool CanHandle(IAction action)
        {
            // @todo & typeof is IHandler
            var interfaces = GetType().GetInterfaces();
            var candidates = interfaces.Where(x => x.IsConstructedGenericType 
                                                && x.GetGenericArguments()[0] == action.GetType());

            return candidates.Any();
        }
    }
    
}