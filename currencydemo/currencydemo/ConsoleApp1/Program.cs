namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        //Sequence();
        Concurrency();
    }

    static void Concurrency()
    {
        Console.WriteLine(">>>started");
        Console.WriteLine("calls asynchronously Method1()");
        var task1 = Task.Run(Method1);
        Console.WriteLine("calls asynchronously Method2()");
        var tak2=Task.Run(Method2);
        Console.WriteLine(">>fininshed");
        //Console.ReadLine();
        Task.WaitAll(task1, tak2);
        Console.WriteLine("Bye...");
    }
    static void Sequence()
    {
        Console.WriteLine("Main() started");
        Console.WriteLine("Main() calls Method1()");
        Method1();
        Console.WriteLine("Main() calls Method2()");
        Method2();
        Console.WriteLine("Main() fininshed");
        Console.ReadLine();
    }
    static void Method1()
    {
        Console.WriteLine("Method1 started");
        Thread.Sleep(2000);
        Console.WriteLine("Method1 fininshed");
    }
    static void Method2()
    {
        Console.WriteLine("Method2 started");
        Thread.Sleep(2000);
        Console.WriteLine("Method2 fininshed");
    }

}
