using System;

namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface IAction
    {
        Guid Identifier { get; set; }
        bool HasResult { get; }


        string Name { get; }
        string Type { get; }
        string Description { get; set; }

    }
}