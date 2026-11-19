using System;
using System.Collections.Generic;

public class DatabaseConfig
{
    public string connectionString { get; set; }
    public DatabaseDetail database { get; set; }
    public List<TableDetail> tables { get; set; }
}

public class DatabaseDetail
{
    public bool isDatabaseDropped { get; set; }
    public string databaseName { get; set; }
    public string dropDatabaseScript { get; set; }
    public string createDatabaseScript { get; set; }
}

public class TableDetail
{
    public string tableName { get; set; }
    public string createScript { get; set; }
}