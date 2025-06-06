using System.Diagnostics;

namespace Demos;

internal unsafe class Example7 : IExample
{
    public static string Title => "Return buffer implemented explicitly";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();
        
        
        var test = (delegate*<long, LargeStruct>)address;

        var result = test(7);

        Console.WriteLine($"Result: {result}");

    }

    public static ref LargeStruct Test(ref LargeStruct returnBuffer, long s)
    {
        Console.WriteLine(s);
        returnBuffer = new LargeStruct(1, 2, 3, 4);
        return ref returnBuffer;
    }
}
