using System.Diagnostics;

namespace Demos;

internal unsafe class Example8 : IExample
{
    public static string Title => "Instance method";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();


        var test = (delegate*<Example8, void>)address;

        test(new Example8 { Name = "Hello" });
    }

    private string Name;
    
    private void Test()
    {
        Console.WriteLine($"this is null: {this is null}");
        Console.WriteLine(this.Name);
    }
}
