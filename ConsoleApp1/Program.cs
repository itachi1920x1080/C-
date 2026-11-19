using EntityCollection;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EntityManager<int, Entity<int>> mgr = new();
            mgr.EntityAdded += (s, e) =>
            {
                Console.WriteLine($"{e.Type} Added: {e.Info}");
            };
            //mgr.Add(new Person(1, "Dk", 40));
            mgr.Add(new Person { Key = 1, Name = "Dk", Age = 40 });
            mgr.Add(new latop { key = 1, name = "Dell", price = 50000, model = "Inspiron" });
        }
    }
}

class Person : Entity<int>
{
    //public Person(int key, string name, int age)
    //{
    //    Key = key;
    //    Name = name;
    //    Age = age;
    //}

    public string Name { get; set; }
    public int Age { get; set; }

    public override string Info => $"Key : {Key},Name {Name}, Age : {Age}";
    public override string GetTextData() => "";
    public override bool SetTextData(string data) => true;

}

class latop : Entity<int>
{
    public int key { get; set; }
    public string name { get; set; }
    public int price { get; set; }
    public string model { get; set; }

    public override string Info => $"Key : {key},Name {name}, price : {price},model : {model}";

    public override string GetTextData() => "";
    public override bool SetTextData(string data) => true;

    //public override bool SetTextData(string data)
    //{
    //    throw new NotImplementedException();
    //}

}