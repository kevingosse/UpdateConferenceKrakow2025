using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Demos;

internal unsafe class Example12 : IExample
{
    public static string Title => "Varargs called explicitly with wrong signature";

    public static void Run()
    {
        Debugger.Break();
        var address = GetTestMethod();

        var sigHelper = SignatureHelper.GetMethodSigHelper(CallingConventions.VarArgs, null);
        sigHelper.AddSentinel();
        sigHelper.AddArgument(typeof(long));
        sigHelper.AddArgument(typeof(long));
        sigHelper.AddArgument(typeof(long));
        sigHelper.AddArgument(typeof(string));
        //sigHelper.AddArgument(typeof(long));
        //sigHelper.AddArgument(typeof(long));
        //sigHelper.AddArgument(typeof(long));
        //sigHelper.AddArgument(typeof(long));
        var signature = sigHelper.GetSignature();

        using var cookie = new VASigCookie(signature);

        var test = (delegate*<VASigCookie*, long, long, long, string, long, long, long, long, void>)address;
        test(&cookie, 1, 2, 3, "hello", 5, 6, 7, 8);
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
