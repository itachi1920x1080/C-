using People.Library;

namespace People.Reference
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            LoadPeople();
            Application.Run(new MainForm());
        }
        private static void LoadPeople()
        {
            string[] lines = File.ReadAllLines("people.txt");

            foreach (string line in lines)
            {
                Person? newPer = Person.Create(line);
                if (newPer != null) LoadedPeople.Add(newPer);
            }
            LoadedPeople.ForEach(p => PeopleMgr.Add(p));
        }
        public static List<Person> LoadedPeople = new();
        public static PeopleManager PeopleMgr { get; set; } = new();
    }
}