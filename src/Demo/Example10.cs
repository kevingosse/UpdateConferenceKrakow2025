using System.Diagnostics;

namespace Demos;

internal class Example10 : IExample
{
    public static string Title => "Varargs";

    public static void Run()
    {
        Debugger.Break();

        Test(__arglist(1, 2, 3, "hello", 5, 6, 7, 8));
    }

    private static void Test(__arglist)
    {
        var argIterator = new ArgIterator(__arglist);
        var argCount = argIterator.GetRemainingCount();

        Console.WriteLine($"ArgCount: {argCount}");

        for (int i = 0; i < argCount; i++)
        {
            var arg = argIterator.GetNextArg();
            Console.WriteLine($"Argument {i + 1}: {TypedReference.ToObject(arg)}");
        }
    }
}
