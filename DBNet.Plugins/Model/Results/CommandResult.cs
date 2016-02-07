using System;
using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Interfaces.Results;

namespace TinyCQRS.Core.Model.Results
{
    public class CommandResult<T> : ICommandResult<T> where T : ICommand
    {
        public bool Success { get; set; }
        public Guid Reference { get; private set; }

        public CommandResult(bool success)
        {
            Success = success;
        }
    }
}
