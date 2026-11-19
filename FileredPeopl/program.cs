using System;
using System.Collections.Generic;
using System.Linq;
using FileredPeopl;

public class Program
{
    static void Pause()
    {
        Console.WriteLine("Enter...");
        Console.ReadKey();
    }

    static void ViewPeople(List<Person> per)
    {
        Console.WriteLine(Person.Heading);
        Console.WriteLine(Person.GetBar());
        per.ForEach(p => Console.WriteLine(p.Info));
        Console.WriteLine(Person.GetBar());
    }

    static void Main(string[] args)
    {
        List<string> data = new List<string>
        {
            "heng Long/Male/23",
            "Mut Dara/Male/29",
            "Tum Sokha/Female/33",
            "Sophea Chan/Female/19"
        };

        int tage = 20;
        List<Person> people = data.Select(x => new Person { Data = x }).ToList();

        Console.WriteLine($"\nPeople with ages > {tage}");
        ViewPeople(people.Where(p => p.Age > tage).ToList());
        Pause();

        Console.WriteLine();
        int maxAge = people.Max(p => p.Age);
        List<Person> maxPeople = people.Where(p => p.Age == maxAge).ToList();
        ViewPeople(maxPeople);
        Pause();

        Console.WriteLine();
        List<Person> orderedPeople = people.OrderBy(p => p.Name).ToList();
        ViewPeople(orderedPeople);
        Pause();
    }
}
