using System;

namespace TinyCQRS.Core.Exceptions
{
    public class PluginEntryPointMissingException : Exception
    {
        public PluginEntryPointMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}