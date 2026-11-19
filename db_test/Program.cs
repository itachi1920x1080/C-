using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using MySqlConnector; // Ensure you ran: dotnet add package MySqlConnector

namespace MySqlInitializer
{
    // --- JSON Model Mapping ---
    public class DatabaseConfig
    {
        public string connectionString { get; set; }
        public DatabaseDetail database { get; set; }
        public List<TableDetail> tables { get; set; }
    }

    public class DatabaseDetail
    {
        public string databaseName { get; set; }
        public string dropDatabaseScript { get; set; }
        public string createDatabaseScript { get; set; }
    }

    public class TableDetail
    {
        public string tableName { get; set; }
        public string createScript { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The file must be in bin/Debug/net8.0/
            string filePath = "config.json";

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: {filePath} was not found.");
                    return;
                }

                // 1. Read and Deserialize
                string jsonContent = File.ReadAllText(filePath);
                var config = JsonSerializer.Deserialize<DatabaseConfig>(jsonContent);

                // 2. Open Connection to MySQL Server
                using var connection = new MySqlConnection(config.connectionString);
                connection.Open();
                Console.WriteLine("Successfully connected to MySQL Server.");

                using var cmd = connection.CreateCommand();

                // 3. Drop & Create Database
                Console.WriteLine($"Initializing Database: {config.database.databaseName}...");
                cmd.CommandText = config.database.dropDatabaseScript;
                cmd.ExecuteNonQuery();

                cmd.CommandText = config.database.createDatabaseScript;
                cmd.ExecuteNonQuery();

                // 4. SWITCH CONTEXT (Crucial Step)
                connection.ChangeDatabase(config.database.databaseName);
                Console.WriteLine("Switched to the new database context.");

                // 5. Create Tables
                foreach (var table in config.tables)
                {
                    Console.WriteLine($"Creating table: {table.tableName}");
                    cmd.CommandText = table.createScript;
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("\nDone! Database and Tables are ready in MySQL Workbench.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Text.Json;
//using Microsoft.Data.SqlClient; // Using SQL Server Client instead of MySQL

//namespace MySqlInitializer
//{
//    public class DatabaseConfig
//    {
//        public string connectionString { get; set; }
//        public DatabaseDetail database { get; set; }
//        public List<TableDetail> tables { get; set; }
//    }

//    public class DatabaseDetail
//    {
//        public string databaseName { get; set; }
//        public string dropDatabaseScript { get; set; }
//        public string createDatabaseScript { get; set; }
//    }

//    public class TableDetail
//    {
//        public string tableName { get; set; }
//        public string createScript { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string filePath = "config.json";

//            try
//            {
//                if (!File.Exists(filePath))
//                {
//                    Console.WriteLine($"Error: {filePath} was not found.");
//                    return;
//                }

//                // 1. Read and Deserialize
//                string jsonContent = File.ReadAllText(filePath);
//                var config = JsonSerializer.Deserialize<DatabaseConfig>(jsonContent);

//                // 2. Open Connection to SQL Server
//                // Note: Ensure connectionString in JSON targets 'master' or has no initial catalog
//                using var connection = new SqlConnection(config.connectionString);
//                connection.Open();
//                Console.WriteLine("Successfully connected to SQL Server.");

//                using var cmd = connection.CreateCommand();

//                // 3. Drop & Create Database
//                Console.WriteLine($"Initializing Database: {config.database.databaseName}...");

//                // SQL Server requires a slightly different approach for dropping/creating
//                cmd.CommandText = config.database.dropDatabaseScript;
//                cmd.ExecuteNonQuery();

//                cmd.CommandText = config.database.createDatabaseScript;
//                cmd.ExecuteNonQuery();

//                // 4. SWITCH CONTEXT
//                connection.ChangeDatabase(config.database.databaseName);
//                Console.WriteLine($"Switched to {config.database.databaseName} context.");

//                // 5. Create Tables
//                foreach (var table in config.tables)
//                {
//                    Console.WriteLine($"Creating table: {table.tableName}");
//                    cmd.CommandText = table.createScript;
//                    cmd.ExecuteNonQuery();
//                }

//                Console.WriteLine("\nDone! Database and Tables are ready in SSMS.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"\nERROR: {ex.Message}");
//            }

//            Console.WriteLine("\nPress any key to exit...");
//            Console.ReadKey();
//        }
//    }
//}