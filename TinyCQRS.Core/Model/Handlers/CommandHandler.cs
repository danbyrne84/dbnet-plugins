using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Handlers
{
    public class CommandHandler : Handler, ICommandHandler
    {

    }

    public abstract class CommandHandler<T> : CommandHandler, ICommandHandler<T> where T : ICommand
    {
        public abstract bool Handle(T command);
    }
}
