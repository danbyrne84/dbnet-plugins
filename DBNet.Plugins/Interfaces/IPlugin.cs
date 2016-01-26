using System.Collections.Generic;
using DBNet.Plugins.Interfaces.Handlers;

namespace DBNet.Plugins.Interfaces
{
    public interface IPlugin
    {
        void Initialize();
        IPluginInformation MetaData { get; set; }
        IEnumerable<IHandler> GetHandlers();
    }
}