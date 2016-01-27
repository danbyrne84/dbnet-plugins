using System.Collections.Generic;
using DBNet.Plugins.Interfaces.Handlers;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Interfaces
{
    public interface IPlugin
    {
        void Initialize();
        IPluginInformation MetaData { get; set; }
        IEnumerable<ICqrsObject> GetExposedMethods();
    }
}