using System.Diagnostics;

namespace Demos;

internal unsafe class Example9 : IExample
{
    public static string Title => "Instance method with null";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();


        var test = (delegate*<Example9, void>)address;

        test(null);
    }

    private string Name;

    public void Test()
    {
        Console.WriteLine($"this is null: {this is null}");
        Console.WriteLine(this.Name);
    }
}
