using System.Collections.Generic;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Interfaces
{
    public interface IPlugin
    {
        // meta
        IPluginMetadata MetaData { get; set; }

        // constructor
        void Initialize();

        // handler functionality
        bool CanHandle(IAction action);
        ICqrsResponse Handle(IAction action);
        IEnumerable<IHandler> Handlers { get; }

        // exposed execution units
        IEnumerable<IAction> ExecutionUnits { get; }
        
    }
}