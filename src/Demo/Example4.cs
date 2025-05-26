using System.Diagnostics;

namespace Demos;

internal unsafe class Example4 : IExample
{
    public static string Title => "Small struct argument by reference";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();
        
        
        var simpleMethod = (delegate*<ref long, void>)address;

        long argument = 7;
        simpleMethod(ref argument);

    }

    private static void Test(long s)
    {
        Console.WriteLine(s);
    }
}
