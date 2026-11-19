using System;

namespace input;

class Program
{
    static void Main(string[] args)
    {
        TestStanddardInput();
        TestFileInput();
    }
    static void TestFileInput()
    {
        Console.SetIn(File.OpenText("data.txt"));
        string? name = Console.ReadLine();
        double price = double.Parse(Console.ReadLine() ?? "0.0");
        int qty = int.Parse(Console.ReadLine() ?? "0");
        Console.In.Close();

        Console.WriteLine("\n[Sale Info.]");
        Console.WriteLine($"Product : {name}");
        Console.WriteLine($"Price   : {price:c2}");
        Console.WriteLine($"Quantity: {qty}");
        double amount = price * qty;
        Console.WriteLine($"Amount  : {amount:c3}");
    }
    static void TestStanddardInput() {
        Console.Write("name ? :");
        string? name = Console.ReadLine();
        Console.Write("age ? :");
        int age = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("\n[Your input ]");
        Console.WriteLine($"name :{name} , age : {age}");
        Console.Write("Any key to exti .... ");
        Console.ReadKey();

    }
}