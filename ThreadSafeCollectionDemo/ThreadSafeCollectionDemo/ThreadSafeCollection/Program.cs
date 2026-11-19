namespace ThreadSafeCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread-Safe");
            Manager mgr = new Manager(1, 10_000, 1_000);
            Console.WriteLine("Generating integers starts...");
            mgr.Generate();
            Console.WriteLine("Generating integers finished");

            var values = mgr.Values.ToArray();
            Console.WriteLine($"Numbers: {values.Length}");
            Console.WriteLine("Viewing all integers (original)");
            values.ToList().ForEach(x => Console.Write($"{x,8}"));


            Console.WriteLine("\nPress any key...");
            Console.ReadKey(true);
            Console.WriteLine("Viewing all integers (sorted)");
            values.OrderBy(x => x).ToList().ForEach(x => Console.Write($"{x,8}"));

        }
    }
}