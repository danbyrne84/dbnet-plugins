using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Interfaces.Results;

namespace DBNet.Plugins.Model.Results
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
