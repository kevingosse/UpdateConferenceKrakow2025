using System.Diagnostics;

namespace Demos;

internal unsafe class Example2 : IExample
{
    public static string Title => "Large struct argument by reference";

    public static void Run()
    {
        Debugger.Break();


        var address = GetTestMethod();
        var test = (delegate*<ref LargeStruct, void>)address;

        var argument = new LargeStruct(1, 2, 3, 4);
        test(ref argument);

    }

    private static void Test(LargeStruct s)
    {
        Console.WriteLine(s);
    }
}
