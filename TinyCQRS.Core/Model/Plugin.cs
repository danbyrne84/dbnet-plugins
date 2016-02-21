using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using TinyCQRS.Core.Interfaces;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;
using TinyCQRS.Core.Model.Internal;
using TinyCQRS.Core.Model.Results;

namespace TinyCQRS.Core.Model
{
    internal class ServiceRegistration
    {
        public Type Service;
        public Type Implementation;
    }

    public abstract class Plugin : IPlugin
    {
        public IPluginMetadata MetaData { get; set;  }

        private const string Unknown = "Unknown";
        private const string PluginDirectory = "plugins";

        private Container _container;

        private IList<Type> AllTypes => GetType().Assembly.GetTypes().ToList();

        // Handlers
        #region Handlers

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

        public Plugin()
        {
            _container = new Container();

            var registrations =
                from type in GetType().Assembly.GetTypes()
                where type.IsClass && type.GetInterfaces().Any(x => x.IsGenericType &&
                        (x.GetGenericTypeDefinition() == typeof(IEventHandler<>) ||
                            x.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                            x.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
                select new ServiceRegistration
                {
                    Service = type.GetInterfaces().Last(),
                    Implementation = type
                };

            // register the handlers
            registrations.ToList().ForEach((ServiceRegistration registration) => {
                _container.Register(registration.Service, registration.Implementation, Lifestyle.Transient);
            });

        }

        public ICommandResult Handle<T>(T command) where T : ICommand
        {
            var handler = _container.GetInstance<ICommandHandler<T>>();

            return handler.Handle(command);
        }

        public IQueryResult<TR> Handle<T, TR>(T query) where TR : class where T : IQuery<T, TR>
        {
            var handler = _container.GetInstance<IQueryHandler<T, TR>>();

            var result = handler.Handle(query);

            var queryResult = new QueryResult<TR>
            {
                Result = result
            };

            return queryResult;
        }

        public bool CanHandle(IAction action)
        {
            return Handlers.Any(x => x.CanHandle(action));
        }
    }
}
