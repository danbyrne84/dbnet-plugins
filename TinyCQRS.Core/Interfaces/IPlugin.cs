using System.Collections.Generic;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;
using TinyCQRS.Core.Model;

namespace TinyCQRS.Core.Interfaces
{
    public interface IPlugin
    {
        // meta
        IPluginMetadata MetaData { get; set; }

        // handler functionality
        bool CanHandle(IAction action);
        IEnumerable<IHandler> Handlers { get; }
        // exposed execution units
        IEnumerable<IAction> ExecutionUnits { get; }
    }
}