using PluginTest.Common;
using System.Reflection;

var pluginsFolder = Path.Combine(
    Directory.GetCurrentDirectory(),
    "plugins");

var assembly = Assembly.LoadFrom(
    Path.Combine(
        pluginsFolder, 
        "PluginTest.Plugin.ImageSharp.dll"));

var modules = assembly.GetTypes()
    .Where(t => t.IsAssignableTo(typeof(IModule)))
    .Select(t => Activator.CreateInstance(t) as IModule)
    .ToArray();

foreach(IModule module in modules)
{
    module.DoSomething();
}

Console.ReadLine();