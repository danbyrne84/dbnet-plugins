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

        private IList<Type> AllTypes => GetType().Assembly.GetTypes().ToList();

        // Handlers
        #region Handlers
        private IHandlerFactory _handlerFactory = new HandlerFactory();
        private IEnumerable<IHandler> _handlers = new List<IHandler>();

        // Execution handlers
        public IEnumerable<IHandler> Handlers
        {
            get
            {
                var handlers = AllTypes.Where(x => typeof(IHandler).IsAssignableFrom(x));
                var typeCollection = new List<IHandler>();

                foreach (var action in handlers)
                {
                    try
                    {
                        var instance = Activator.CreateInstance(action) as IHandler;
                        typeCollection.Add(instance);
                    }
                    catch (Exception)
                    {
                        //@todo log, for now just silently ignore
                    }
                }

                return typeCollection;
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
                var executionUnits = AllTypes.Where(x => typeof (IAction).IsAssignableFrom(x));
                var typeCollection = new List<IAction>();

                foreach (var action in executionUnits)
                {
                    try
                    {
                        var instance = Activator.CreateInstance(action) as IAction;
                        typeCollection.Add(instance);
                    }
                    catch (Exception)
                    {
                        //@todo log, for now just silently ignore
                    }
                }
                return typeCollection;
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
