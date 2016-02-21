using System;
using TinyCQRS.Core.Model;

namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface IAction
    {
        Guid Identifier { get; set; }
        bool HasResult { get; }


        string Name { get; }
        ActionType Type { get; }
        string ReturnType { get; set; }
        string Description { get; set; }

    }
}