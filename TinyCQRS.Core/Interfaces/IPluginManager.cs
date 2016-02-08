using System.Collections.Generic;

namespace TinyCQRS.Core.Interfaces
{
    public interface IPluginManager
    {
        List<IPlugin> Plugins { get; set; }
        List<IPlugin> LoadPlugins(string path, string name = null, bool recursive = false);
    }
}