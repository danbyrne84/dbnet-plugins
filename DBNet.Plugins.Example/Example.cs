using System;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Model;

namespace DBNet.Plugins.Example
{
    public class Example : Plugin, IPlugin
    {
        public void Initialize()
        {
            Console.WriteLine(GetType());
            Console.WriteLine("Example :: Initialize called.");

        }
    }
}
