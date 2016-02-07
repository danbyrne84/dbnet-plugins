using System;
using System.Collections.Generic;
using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model
{
    public class HandlerFactory : IHandlerFactory
    {
        protected List<ICommandHandler> CommandHandlers { get; set; }  // ??

        public ICqrsResponse Handle(IAction action)
        {
            var success = false; // always assume the worst!!

            // find handlers capable of handling this Action


            Console.WriteLine(nameof(action));

            return new CqrsResponse {Success = success};
        }
    }
}
