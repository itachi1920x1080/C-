using System;
using System.IO;
namespace mm;

class Program
{
    public string name = "";
    public string gender="";
    public int age;
    static void Main(string[] args)
    {
        Program p = new Program();
        bool line =p.seltextData("itachi/male/20");
        string bar = new string('-', 60);
        Console.WriteLine(bar);
        if (!line)
        {
            Console.WriteLine("data error");
            return;
        }
        Console.WriteLine($"{"Name",20}{"Gender",20}{"Age",20}");
        Console.WriteLine(bar);
        Console.WriteLine($"{p.name,20}{p.gender,20}{p.age,20}");
        p.Testfilleinput();
        Console.WriteLine(bar);
    }

    public void Testfilleinput()
    {
        // Console.SetIn(File.OpenText(@"C:\Users\itach\OneDrive\Desktop\People\People.txt"));
        Console.SetIn(File.OpenText("People.txt"));
        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            seltextData(line);
            Console.WriteLine($"{name,20}{gender,20}{age,20}");
        }
    }

    public bool seltextData (string data)
    {
        var arr = data.Split('/');
        if (arr.Length < 3 )  return false;
        name = arr[0];
        gender = arr[1];
        age = int.Parse(arr[2]);
        return true;
    }

}
