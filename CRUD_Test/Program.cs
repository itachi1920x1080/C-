using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Reflection;
namespace CRUD_Test;

internal class Program
{
    static string connString = @"server=ITACHI\SQLEXPRESS;database=enrolldb;trusted_connection=true;encrypt=false";
    static SqlConnection conn = new SqlConnection(connString);

    static void Main(string[] args)
    {
        try
        {
            conn.Open();
            Console.WriteLine("Connneting to data soucre ......");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return;
        }
        finally { conn.Close(); }
        ShowStudent();
    }

    static void ShowStudent()
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM student";
        var reader = cmd.ExecuteReader();
        if (!reader.HasRows)
        {
            Console.WriteLine("No student found.");
            return;
        }
        while (reader.Read() == true)
        {
            var stu = Student.ToStudent(reader);
            if (stu != null)
            {
                Console.WriteLine(stu.Info);
            }
        }
    }



    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int gender { get; set; }
        public int age { get; set; }

        public string Info => $"[{Id}] {Firstname} {Lastname} | Gender: {(gender == 0 ? "Female" : "Male")} | Age: {age}";
        public static Student? ToStudent(SqlDataReader reader)
        {
            Student? result = null;
            try
            {
                result = new Student()
                {
                    Id = reader.GetInt32("id"),
                    Firstname = reader.GetString("FirstName"),
                    Lastname = reader.GetString("LastName"),
                    gender = reader.GetInt32("Gender"),
                    age = reader.GetByte("Age")
                };

            }
            catch (Exception) { }
            return result;
        }
    }
}