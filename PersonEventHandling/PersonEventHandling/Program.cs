using System.Diagnostics.Tracing;

namespace PersonEventHandling;

internal class Program
{
    static List<Person> ovver20Pers = [];
    static List<Person> allPers = new();
    static void Main(string[] args)
    {
        //Test1();
        Test2();
        
    }
    static void Test2()
    {
        PersonList personList = new PersonList();
        
        Person.Create("Heng Map", "Male", 34);
        Person.Create("Doung Nita", "Female", 25);
        Person.Create("Chan Dara", "Male", 45);
        Person.Create("Mut Vanny", "Female", 23); 
        Person.Create("Vong Nary", "Female", 21);

        var pers = personList.Elements;
        personList.Genders.ForEach(g =>
        {
            Console.WriteLine($"[{g}]");
            pers.Where(p => p.Gender == g)
                .ToList()
                .ForEach(p => Console.WriteLine($"\tage:{p.Age}, name:{p.Name}"));
        });

        Console.WriteLine("\nAll people in ascending of names");
        pers.OrderByDescending(p => p.Name).ToList()
            .ForEach(p => Console.WriteLine(p.Info));
    }
    static void Test1()
    {
        //Person.Created += new Person.PersonEventHandler(
        //    (Person p)=> { pers.Add(p); }
        //    );
        Person.Created += new Person.PersonEventHandler(OnPersonCreated);
        Person.Created += OnPersonCreated2;
        Console.WriteLine(ovver20Pers.Count);
        Person.Create("Heng Map", "male", 23);
        Person.Create("Heng Meo", "male", 15);
        Person.Create("Heng Mouy", "female", 12);
        Person.Create("Heng Mean", "female", 8);
        Console.WriteLine(ovver20Pers.Count);

        Console.WriteLine("\nHere are all created people");
        foreach (var p in allPers)
        {
            Console.WriteLine(p.Info);
        }
    }
    private static void OnPersonCreated2(Person person)
    {
        Console.WriteLine($"A person aged {person.Age} was created");
        allPers.Add(person);
    }
    private static void OnPersonCreated(Person per)
    {
        Console.WriteLine($"A person named {per.Name} was created");
        if ( per.Age>20) 
            ovver20Pers.Add(per);
    }
}
