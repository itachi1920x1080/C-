using System.Numerics;

namespace mm;

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        string allinfo = "" ;
        double total = 0;

        while (true)
        {
            Console.WriteLine("Rectangles");
            Console.Write($"[{n+1}]:");
            var input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Finished");
                break;
            }
            var arr = input.Split(" ");
            if (arr.Length < 2)
            {
                Console.WriteLine("Not eniug enough data");
                continue;
            }
            double width = double.Parse(arr[0]);
            double Length = double.Parse(arr[1]);
            double area = width * Length;
            Console.WriteLine($"Area: {area}");
            total += area;
            n++; 
            var info = $"{n,6}{width,10:n2}{Length,10:n2}{area,10:n2}";
            if (allinfo != "") allinfo += "\n";
            allinfo += info;
        }
        string hading = $"{"[NO]",6}{"[Winth]",10}{"[length]",10}{"[Area]",10}";
        string taoatlinfo = $"Taotal : {total:c2}";
        string bar = new string('-', hading.Length);
        Console.WriteLine();
        Console.WriteLine (bar);
        Console.WriteLine(hading) ;
        Console.WriteLine(allinfo);
        Console.WriteLine(bar);
        Console.WriteLine($"{taoatlinfo,39:c3}");

    }

}
