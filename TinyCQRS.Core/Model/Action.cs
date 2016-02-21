using System;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model
{
    public enum ActionType
    {
        Command,
        Query,
        Event,
        Unknown
    }
    public abstract class Action : IAction
    {
        public Guid Identifier { get; set; }
        public bool HasResult { get; }
        public string Name => GetType().Name;
        public ActionType Type
        {
            get
            {
                //@todo - better
                var t = GetType();

                if (typeof (ICommand).IsAssignableFrom(t))
                {
                    return ActionType.Command;
                }

                if (typeof (IQuery).IsAssignableFrom(t))
                {
                    return ActionType.Query;
                }

                if (typeof (IEvent).IsAssignableFrom(t))
                {
                    return ActionType.Event;
                }

                return ActionType.Unknown;
            }
        }
        public string ReturnType { get; set; }
        public string Description { get; set; }
    }
}
