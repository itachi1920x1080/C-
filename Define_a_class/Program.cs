using Microsoft.VisualBasic;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Define_a_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //
            Computer test = new Computer("TUF17", "Ausu");
            //Console.WriteLine($"orginal : {test.Brean}|{test.Model}");
            Console.WriteLine(test.Info);
            // Modify 
            test.Model = "ROG ST Sart";
            test.Brean = "ROG ST";
            //Console.WriteLine($"Modify :{test.Brean} |{test.Model}");
            Console.WriteLine(test.Info);
            test.Beep();

        }

        public class Computer : Program
        {
            //fields
            private string model;
            private string brean;
            //constructor
            public Computer(string model, string brean)
            {
                this.model = model;
                this.brean = brean;
            }


            public string Model  // property
            {
                get { return model; }
                set { model = value; }
            }
            public string Brean  //proprty
            {
                get { return brean; }
                set {  brean = value; }
            }

            public string Info  // property info
            {
                get
                {
                    return $"{this.Model}|{this.Brean}";

                }

            }

            public void Beep()
            {
                Console.WriteLine("Beep!");
            }
           

        }
    }
}
