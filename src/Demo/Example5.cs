using System.Diagnostics;

namespace Demos;

internal unsafe class Example5 : IExample
{
    public static string Title => "Return buffer";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();
        
        
        var test = (delegate*<long, LargeStruct>)address;

        var result = test(7);

        Console.WriteLine($"Result: {result}");

    }

    public static LargeStruct Test(long s)
    {
        Console.WriteLine(s);
        return new LargeStruct(1, 2, 3, 4);
    }
}
