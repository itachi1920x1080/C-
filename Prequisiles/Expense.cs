using System.Runtime.CompilerServices;

namespace ConsoleApp8;

public class Expense
{
    public int No { get; set; } = 0;
    public double Amount { get; set; } = 0;
    public string Descr { get; set; } = "";

    private static string field_no = nameof(No).ToLower();
    private static string field_amount = nameof(Amount).ToLower();
    private static string field_descr = nameof(Descr).ToLower();    
    private static List<string> fields =[field_no, field_amount, field_descr];
    public static Expense? Create(string data)=>Create(data.ToDictionary(",", ":"));
    
    public static Expense? Create(Dictionary<string, object> data)
    {
        int no=0;
        double amount=0;
        string descr="";
        foreach (var key in data.Keys)
        {
            if (fields.Contains(key.ToLower()) == false) return null;
            if (key.ToLower() == field_no)
            {
                if (int.TryParse(data[key].ToString(), out no) == false) return null;
            }
            if (key.ToLower() == field_amount)
            {
                if (double.TryParse(data[key].ToString(), out amount) == false) return null;
            }
            if (key.ToLower() == field_descr)
            {
                descr = data[key]?.ToString() ?? "";
            }
        }
        return new Expense()
        { 
            No = no,
            Amount = amount,
            Descr = descr
        };
        
    }
}
