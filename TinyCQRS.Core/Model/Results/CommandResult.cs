using System;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;

namespace TinyCQRS.Core.Model.Results
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid Reference { get; private set; }

        public CommandResult(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
