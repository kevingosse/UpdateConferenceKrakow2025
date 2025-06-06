using System.Diagnostics;

namespace Demos;

internal unsafe class Example3 : IExample
{
    public static string Title => "Small struct argument";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();
        
        
        var test = (delegate*<long, void>)address;

        test(7);

    }

    public static void Test(long s)
    {
        Console.WriteLine(s);
    }
}
