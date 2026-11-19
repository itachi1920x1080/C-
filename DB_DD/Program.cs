using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using MySqlConnector;
namespace DB_DD;

public class Database
{
    public bool isDatabaseDropped { get; set; }
    public string databaseName { get; set; }
    public string dropDatabaseScript { get; set; }
    public string createDatabaseScript { get; set; }
}

public class Root
{
    public string connectionString { get; set; }
    public Database database { get; set; }
    public List<Table> tables { get; set; } 
}

public class Table
{
    public string tableName { get; set; }
    public string createScript { get; set; }
}

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Loading JSON FILE ...");
        var file = "config.json";
        var jsonData = File.ReadAllText(file);
        var root = JsonSerializer.Deserialize<Root>(jsonData);

        Console.WriteLine("Conneting to data soure ....");
        using var conn = new MySqlConnection(root.connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        if (root.database.isDatabaseDropped)
        {
            Console.WriteLine($"Dropping database {root.database.databaseName} ...");
            cmd.CommandText = root.database.dropDatabaseScript;
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine($"Create database ,{root.database.databaseName}...");
        cmd.CommandText = root.database.createDatabaseScript;
        cmd.ExecuteNonQuery();
        cmd.CommandText = $"USE {root.database.databaseName};";
        cmd.ExecuteNonQuery();

        Console.WriteLine($"Creating Table .....");
        foreach(var table in root.tables)
        {
            Console.WriteLine($"Creating table {table.tableName} ...");
            cmd.CommandText = string.Format(table.createScript, table.tableName);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Process finished successfully.");
    }
}
