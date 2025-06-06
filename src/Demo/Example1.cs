using System.Diagnostics;

namespace Demos;
internal unsafe class Example1 : IExample
{
    public static string Title => "Large struct argument";

    public static void Run()
    {
        Debugger.Break();


        IntPtr address = GetTestMethod();
        var test = (delegate*<LargeStruct, void>)address;

        test(new LargeStruct(1, 2, 3, 4));

    }

    public static void Test(LargeStruct s)
    {
        Console.WriteLine(s);
    }
}
