using PeopleLibrary;
using System.Text.Json;

namespace PeopleStorageSaving
{
    internal class Program
    {
        static string filename = "../../../../data/people.json";
        static void Main(string[] args)
        {
            if (args.Length >0) 
            {
                filename = args[0];
            }
            if (TryCreateFile() == false) return;
            Console.WriteLine("Input people data");
            int count = 0;
            while (true)
            {
                Console.WriteLine($"[{count+1}]");
                var input = GetInputPerson();
                if (input != null)
                {
                    SavePerson(input);
                    count++;
                }
                Console.WriteLine();
                if (PromptForEscapeKey("Press Escape to stop, any key for more input...") == true) break;
                Console.WriteLine();
            }
            Console.WriteLine($"\n{count} people were saved to file {filename}");
        }
        static bool PromptForEscapeKey(string text)
        {
            Console.Write(text);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine();
                return true;
            }
            Console.WriteLine(keyInfo.KeyChar);
            return false;
        }
        static bool TryCreateFile()
        {
            try
            {
                new FileStream(filename, FileMode.OpenOrCreate).Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error> {ex.Message}");
                return false;
            }
        }
        static PersonX? GetInputPerson()
        {
            Console.Write("Person(id/name/gender/age): ");
            string perData = Console.ReadLine() ?? "";
            Console.Write("Expenses(amount/description[;amount/descriptoin;...] :");
            string expsData = Console.ReadLine() ?? "";
            var dataParts = perData.Split("/");
            if (dataParts.Length <4 ) 
            {
                Console.WriteLine("Invalid person data");
                return null;
            }
            int.TryParse(dataParts[0], out var id);
            var name = dataParts[1].Trim();
            var gender = dataParts[2].Trim();
            byte.TryParse(dataParts[3], out var age);

            var person = new PersonX() { Id = id, Name = name, Gender = gender, Age = age, Expenses = new() };
            expsData.Trim();
            if (expsData != "")
            {
                var expsParts = expsData.Split(";");
                if (expsParts.Length > 0)
                {
                    foreach (var part in expsParts)
                    {
                        var arr = part.Split("/");
                        if (arr.Length > 0)
                        {
                            double.TryParse(arr[0], out var amount);
                            var descr = arr[1].Trim();
                            person.Expenses.Add(new Expense() { Description = descr, Amount = amount });
                        }
                    }
                }
            }
            return person;

        }
        static bool SavePerson(PersonX person)
        {
            try
            {
                List<PersonX>? people = null;
                using (var fs = new FileStream(path: filename, mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite))
                {
                    
                    using (var sr = new StreamReader(fs))
                    {
                        var contents = sr.ReadToEnd();
                        if (contents != "")
                        {
                            try
                            {
                                people = JsonSerializer.Deserialize<List<PersonX>>(contents, 
                                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                            }
                            catch (Exception) { }
                        }
                    }
                }

                people ??= new();
                people.Add(person);
                using (var fs = new FileStream(path: filename, mode: FileMode.Create))
                { 
                    using (var sw = new StreamWriter(fs))
                    {
                        var json = JsonSerializer.Serialize(people, 
                                            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        sw.Write(json);
                    }
                }
                
                Console.WriteLine(">>Successfull saved");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($">>Failed to save > {ex.Message}");
                return false;
            }
        }
    }
}