namespace ConsoleApp8
{
    internal class Program
    {
        static int x = 0;
        static object datalock = new();
        static event EventHandler<int>? handler;
        static void Main(string[] args)
        {
            handler += (sender, e) => 
            { Task.Run(() => { Console.WriteLine(e); });     };
            Task.Run(() => { Method1(); });
            Task.Run(() => { Method2(); });
            Console.ReadLine();
        }

        static void Method1()
        {
            int temp = 0;
            Thread.CurrentThread.Name = "Method1";
            int count = 0;
            while (count++ < 100)
            {
                lock (datalock)
                {
                    x =temp= (int)Random.Shared.Next(500, 1000) * 2 + 1;
                    handler?.Invoke(null, temp);
                }
                Thread.Sleep(20);
            }
        }
        static void Method2()
        {
            int temp = 0;
            int temp2 = 0;
            Thread.CurrentThread.Name = "Method2";
            int count = 0;
            while (count++ < 100)
            {
                lock (datalock)
                {
                    x =temp= (int)Random.Shared.Next(100, 500) * 2;
                    handler?.Invoke(null, temp);
                }
                Thread.Sleep(20);
                temp2 = x;
                Console.WriteLine($"Method2>({temp}, {temp2})=>{temp==temp2}");
            }
        }
    }
}
