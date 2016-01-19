using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins;

namespace DBNet.Plugins.Example
{
    public class Example : IPlugin
    {
        public IEnumerable<IHandler> Handlers => new List<Handler>();

        public IPluginInformation MetaData => new PluginInformation
        {
            Name = "Example Plugin",
            Description = "Description here",
            EntryPoint = "Main",
            Handlers = new[] {"", ""}
        };

        public void Initialize()
        {
            Console.WriteLine("Some initialization tasks here");
        }
    }
}
