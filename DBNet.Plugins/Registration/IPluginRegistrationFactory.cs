using TinyCQRS.Core.Interfaces;

namespace TinyCQRS.Core.Registration
{
    public interface IPluginRegistrationFactory
    {
        IPlugin RegisterPlugin(string path, IPluginMetadata metadata);
    }
}