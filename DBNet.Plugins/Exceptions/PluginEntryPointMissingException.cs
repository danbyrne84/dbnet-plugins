using System;

namespace DBNet.Plugins.Exceptions
{
    public class PluginEntryPointMissingException : Exception
    {
        public PluginEntryPointMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}