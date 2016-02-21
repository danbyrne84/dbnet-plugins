using System;
using System.Linq;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Internal
{
    public abstract class Action : IAction
    {
        public Guid Identifier { get; set; }

        public bool HasResult => GetType().Assembly.GetTypes().Any(t => typeof(IActionResult).IsAssignableFrom(t));

        public string Name => GetType().FullName;

        public abstract ActionType Type { get; set; }
        public abstract string ReturnType { get; set; }

        public string Description { get; set; }
    }
}