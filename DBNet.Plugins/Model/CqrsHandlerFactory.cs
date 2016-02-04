using System;
using System.Collections.Generic;
using DBNet.Plugins.Interfaces.Handlers;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Model
{
    public class CqrsHandlerFactory : ICqrsHandlerFactory
    {
        protected List<ICommandHandler> CommandHandlers { get; set; }  // ??

        public ICqrsResponse Handle(ICqrsObject @object)
        {
            var success = false; // always assume the worst!!

            // find handlers capable of 

            Console.WriteLine(@object.Name);

            return new CqrsResponse {Success = success};
        }
    }
}
