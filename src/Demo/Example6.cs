using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Demos;

internal unsafe class Example6 : IExample
{
    public static string Title => "Return buffer called explicitly";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();
        
        
        var test = (delegate*<ref LargeStruct, long, ref LargeStruct>)address;

        LargeStruct returnBuffer = default;
        ref var result = ref test(ref returnBuffer, 7);

        Console.WriteLine($"Result: {result}");
        Console.WriteLine($"Return buffer: {returnBuffer}");
        Console.WriteLine($"Are same: {Unsafe.AreSame(ref result, ref returnBuffer)}");

    }

    public static LargeStruct Test(long s)
    {
        Console.WriteLine(s);
        return new LargeStruct(1, 2, 3, 4);
    }
}
