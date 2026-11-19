using PeopleLibrary;
using System.Text.Json;

namespace PeopleStorageLoading
{
    internal class Program
    {
        static string filename = "../../../../data/people.json";
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                filename = args[0];
            }
            if (File.Exists(filename) == false)
            {
                Console.WriteLine($"The file, {filename}, does not exist");
                return;
            }
            var people = GetPeople();
            if (people == null) { return; }
            Console.WriteLine($"Loaded people: {people.Count}");
            Console.WriteLine($"{"[Id]",8} {"[Name]",-30} {"[Gender]",-8} {"[Age]",5} {"[Expense Total($)]",-40}");
            Console.WriteLine(new string('=', 55 + 40));
            foreach(var p in people.OrderBy(p => p.Id))
            {
                Console.WriteLine($"{p.Id,8} {p.Name,-30} {p.Gender,-8} {p.Age,5} {p.TotalAmount:n2}");
                if (p.Expenses.Any())
                {

                    foreach (var exp in p.Expenses)
                    {
                        Console.Write(new string(' ', 55));
                        Console.WriteLine($"{exp.Amount,8:n2} > {exp.Description}");
                    }
                }
            }
        }

        static List<PersonX>? GetPeople()
        {
            try
            {
                List<PersonX>? result=null;
                using (var reader = new StreamReader(filename)) 
                {
                    var json = reader.ReadToEnd();
                    result=JsonSerializer.Deserialize<List<PersonX>>(json, 
                        new JsonSerializerOptions() { PropertyNamingPolicy= JsonNamingPolicy.CamelCase});
                }

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to load > {ex.Message}");
                return null;
            }
        }
    }
}