using System;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Results;
using SimpleInjector;
using TinyCQRS.Core.Model.Results;

namespace TinyCQRS.Core.Model.Handlers
{
    public class CommandHandler : Handler
    {
        private readonly Container _container;

        // for the TinyCQRS action resolver
        public CommandHandler(Container container)
        {
            _container = container;
        }

        // for resolved handlers - don't expose IoC container
        public CommandHandler()
        {
            
        }

        public override ActionType HandlerType => ActionType.Command;

        public ICommandResult Handle(dynamic command, bool rethrow = false)
        {
            try
            {
                var handlerType = typeof (ICommandHandler<>);
                var commandType = command.GetType();
                var genericType = handlerType.MakeGenericType(commandType);

                var handler = (dynamic)_container.GetInstance(genericType);
                return handler.Handle(command);
            }
            catch (Exception ex)
            {
                if (rethrow) throw new CommandHandlerException(ex);

                return new CommandResult(false, $"Error handling command {command} - {ex}");
            }
        }
    }
}
