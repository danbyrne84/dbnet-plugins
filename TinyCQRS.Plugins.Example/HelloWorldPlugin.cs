using System;
using TinyCQRS.Core.Model;

namespace TinyCQRS.Plugins.Example
{
    public class HelloWorldPlugin : Plugin
    {
        public HelloWorldPlugin()
        {
            
        }

        public override void Initialize()
        {
            // initialization tasks here
            Console.WriteLine($"{GetType()} - Initialize.");
        }
    }
}
