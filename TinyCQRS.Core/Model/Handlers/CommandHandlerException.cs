using System;
using System.Runtime.Serialization;

namespace TinyCQRS.Core.Model.Handlers
{
    [Serializable]
    internal class CommandHandlerException : Exception
    {
        private Exception ex;

        public CommandHandlerException()
        {
        }

        public CommandHandlerException(string message) : base(message)
        {
        }

        public CommandHandlerException(Exception ex)
        {
            this.ex = ex;
        }

        public CommandHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}