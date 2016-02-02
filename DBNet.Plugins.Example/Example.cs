using System;
using DBNet.Plugins.Interfaces;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Model;

namespace DBNet.Plugins.Example
{
    public class Example : Plugin
    {
        public new void Initialize()
        {
            Console.WriteLine(GetType());
            Console.WriteLine("Example :: Initialize called.");
        }

        public override bool CanHandle(string strongName)
        {
            Console.WriteLine(string.Concat(GetType(), " :: CanHandle" ));
            return true;
        }

        public override ICqrsResponse Handle(ICqrsObject action)
        {
            Console.WriteLine(string.Concat(GetType(), " :: Handle"));

            return new CqrsResponse {Success = true};
        }
    }
}
