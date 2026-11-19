//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace ConsoleApp8
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string filePath = "expdata.txt";

//            // 1. Setup: Create the file with your sample data
//            // (I included the mixed format line 'Descr=Shopping' to test the fix)
//            List<string> sampleData = new List<string>
//            {
//                "No:1, Descr:Foods, Amount:700",
//                "No:12, Descr:Studying, Amount:500",
//                "Amount:300, No:15, Descr:Picnics",
//                "Descr=Shopping, Amount:200, No:33", 
//                "Amount:150, Descr:Other, No:11"
//            };
//            File.WriteAllLines(filePath, sampleData);
//            Console.WriteLine($"[INFO] File '{filePath}' created successfully.\n");

//            // ============================================
//            // START OF PROGRAM 2 TASKS
//            // ============================================

//            List<Expense> expenses = new List<Expense>();

//            if (File.Exists(filePath))
//            {
//                string[] lines = File.ReadAllLines(filePath);

//                foreach (var line in lines)
//                {
//                    // Call the factory method to parse the line
//                    Expense? exp = Expense.Create(line);

//                    if (exp != null)
//                    {
//                        expenses.Add(exp);
//                    }
//                    else
//                    {
//                        Console.WriteLine($"[WARNING] Could not parse line: {line}");
//                    }
//                }
//            }

//            // Print Summary
//            Console.WriteLine("--- Expense Summary ---");
//            Console.WriteLine($"{"No",-5} | {"Description",-15} | {"Amount",10}");
//            Console.WriteLine(new string('-', 36));

//            foreach (var e in expenses)
//            {
//                Console.WriteLine($"{e.No,-5} | {e.Descr,-15} | {e.Amount,10:N0}");
//            }

//            Console.WriteLine(new string('-', 36));

//            // Calculate Total
//            double total = expenses.Sum(x => x.Amount);
//            Console.WriteLine($"{"TOTAL",-23} | {total,10:N0}");

//            Console.ReadKey();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp8
{
    class Program2
    {
        // នេះគឺជា Main method សម្រាប់ Program 2
        static void Main(string[] args)
        {
            string filePath = "expdata.txt";

            // ១. ពិនិត្យមើលថាតើមានឯកសារឬនៅ?
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: រកមិនឃើញឯកសារ 'expdata.txt' ទេ។ សូមដំណើរការ Program 1 ជាមុនសិន។");
                return;
            }

            Console.WriteLine("--- READING EXPENSES ---");

            // 1. Read file and parse ONCE
            var expenses = File.ReadAllLines(filePath)
                               .Select(line => Expense.Create(line))
                               .Where(exp => exp != null)
                               .ToList(); // Converts to List in memory

            // 2. Calculate Max and Min from the list
            var maxAmount = expenses.Max(e => e.Amount);
            var minAmount = expenses.Min(e => e.Amount);

            // ៣. បង្ហាញក្បាលតារាង (Header)
            Console.WriteLine($"{"No",-5} | {"Description",-15} | {"Amount",10}");
            Console.WriteLine(new string('-', 35));

            // ៤. បង្ហាញទិន្នន័យនីមួយៗ
            foreach (var e in expenses)
            {
                Console.WriteLine($"{e.No,-5} | {e.Descr,-15} | {e.Amount,10:N2}");
            }
            Console.WriteLine(new string('-', 35));
            double total = expenses.Sum(e => e.Amount);
            Console.WriteLine($"TOTAL ({expenses.Count} items):      {total,10:N2}");
            Console.WriteLine($"{new string('-', 13)} Summary {new string('-', 13)}");
            //Console.WriteLine($"'-',35{"Summeary"}");
            //double total = expenses.Sum(e => e.Amount);
    
            Console.WriteLine($"Expense : {expenses.Count}");
            Console.WriteLine($"Toatal : {total,10:N2}");
            Console.WriteLine($"Max  Expense: {maxAmount:N2}");
            Console.WriteLine($"Min Expense:  {minAmount:N2}");

            Console.ReadKey();
        }
    }
}