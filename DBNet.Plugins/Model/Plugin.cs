using System;
using System.Collections.Generic;
using System.Linq;
using TinyCQRS.Core.Interfaces;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model
{
    public abstract class Plugin : IPlugin
    {
        public IPluginMetadata MetaData { get; set;  }

        private const string Unknown = "Unknown";
        private const string PluginDirectory = "plugins";

        // Handlers
        #region Handlers
        private IHandlerFactory _handlerFactory = new HandlerFactory();
        private IEnumerable<IHandler> _handlerObjects = new List<IHandler>();

        // Execution handlers
        public IEnumerable<IHandler> Handlers
        {
            get
            {
                return _handlerObjects = _handlerObjects ??
                                   this.GetType().Assembly.GetTypes()
                                       .ToList()
                                       .Where(x => typeof(IHandler).IsAssignableFrom(x))
                                       .Select(Activator.CreateInstance) as IEnumerable<IHandler>;
            }
        }
        #endregion

        // Execution units
        #region Execution Units
        private IEnumerable<IAction> _executionUnits = new List<IAction>();
        public IEnumerable<IAction> ExecutionUnits
        {
            get
            {
                return _executionUnits = _executionUnits ??
                                   this.GetType().Assembly.GetTypes()
                                       .ToList()
                                       .Where(x => typeof(IAction).IsAssignableFrom(x))
                                       .Select(Activator.CreateInstance) as IEnumerable<IAction>;
            }
        }
        #endregion

        // find the appropriate method and execute it

        public ICqrsResponse Handle(IAction action)
        {
            return Handlers.FirstOrDefault(x => x.CanHandle(action))?.Handle(action) ?? new CqrsResponse();
        }

        // abstract constructor
        public abstract void Initialize();

        public bool CanHandle(IAction action)
        {
            return Handlers.Any(x => x.CanHandle(action));
        }

    }
}
