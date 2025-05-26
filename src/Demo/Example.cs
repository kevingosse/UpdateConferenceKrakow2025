using System.Diagnostics;
using System.Reflection;

namespace Demos;

internal interface IExample
{
    static abstract string Title { get; }
    static abstract void Run();
    
    static nint GetTestMethod()
    {
        var stacktrace = new StackTrace(1);
        
        var frame = stacktrace.GetFrame(0);
        
        var type = frame.GetMethod().DeclaringType;
        
        return type
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Single(m => m.Name == "Test")
            .MethodHandle.GetFunctionPointer();
    }
}