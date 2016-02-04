using System.Collections.Generic;
using DBNet.Plugins.Interfaces;

namespace DBNet.Plugins.Management
{
    public interface IPluginManager
    {
        List<IPlugin> Plugins { get; set; }
        List<IPlugin> LoadPlugins(string path, string name = null, bool recursive = false);
    }
}