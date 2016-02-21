using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TinyCQRS.Core.Management;
using TinyCQRS.Plugins.Example;
using TinyCQRS.Plugins.Example.ExecutionUnits;
using TinyCQRS.Plugins.Example.Handlers;
using static System.Console;

namespace TinyCQRS.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // craete an instance of a pluginmanager
            var manager = new PluginManager();

            // find plugin directory
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (exePath == null) { throw new ApplicationException("executable assembly path could not be determined"); }

            var pluginPath = Path.Combine(exePath, "plugins");
            if (Directory.Exists(pluginPath) == false) { throw new ApplicationException("plugin subdirectory not found"); }
            
            // load any plugins in the plugin directory
            var plugins = manager.LoadPlugins(pluginPath);
            if (plugins.Any() == false) { throw new ApplicationException($"no plugins found in assembly at ${exePath}"); }

            // just write out the defined handlers and execution units
            plugins.ForEach(p =>
            {
                var handlers = p.Handlers.Any() ? string.Join(",", p.Handlers.Select(x => x.ToString().ToArray())) : "[none defined]";
                var executionUnits = p.ExecutionUnits.Any() ? string.Join(",", p.ExecutionUnits.Select(x => x.ToString())) : "[none defined]";

                Write($@"
-------------------------------
TinyCQRS.TestApp
Plugin: {p.MetaData.Name}
-------------------------------
Handlers: {p.Handlers.Count()}
_________
|_>>>
      {handlers.ToString()}
Execution Units:
________________
|_>>>
      {executionUnits.ToString()}
-------------------------------
Beginning test execution:

");
                WriteLine(handlers);
            });

            // run some real methods - lets store a name against a user ID and then retrieve it.
            WriteLine("Instantiating HelloWorldPlugin");
            var plugin = new HelloWorldPlugin();

            var command = new HelloWorldCommand { UserId = 1, Name = "second test" };
            WriteLine($"Sending HelloWorldCommand: {command.UserId}, {command.Name}");

            var cmdResult = plugin.Handle(command);
            WriteLine($"Handled command with result: {cmdResult.Success}" );

            var query = new HelloWorldQuery {UserId = 1};
            WriteLine($"Sending HelloWorldQuery: {query.UserId}");

            var queryResult = plugin.Handle<HelloWorldQuery, HelloWorldQueryResult>(query);
            WriteLine($"Handled query with result: {queryResult.Result.UserName}");

            ReadKey();
        }
    }
}
