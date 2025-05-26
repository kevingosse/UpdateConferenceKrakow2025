namespace Demos;

internal class Demo
{
    public static void Run()
    {
        RunExample<Example1>();
        RunExample<Example2>();
        RunExample<Example3>();
        RunExample<Example4>();
        RunExample<Example5>();
        RunExample<Example6>();
        RunExample<Example7>();
        RunExample<Example8>();
        RunExample<Example9>();
        RunExample<Example10>();
        RunExample<Example11>();
        RunExample<Example12>();
    }

    private static void RunExample<T>() where T : IExample
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine(T.Title);
        Console.WriteLine("---------------------------");

        try
        {
            T.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();
    }
}
