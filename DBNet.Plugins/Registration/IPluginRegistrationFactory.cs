using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Model;

namespace DBNet.Plugins.Registration
{
    public interface IPluginRegistrationFactory
    {
        IPlugin RegisterPlugin(string path, IPluginInformation metadata);
    }
}