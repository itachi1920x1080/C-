using System.Text.Json.Serialization;

namespace PeopleLibrary;

public class PersonX: Person
{
    public List<Expense> Expenses { get; set; } = new();
    
    [JsonIgnore]
    public double TotalAmount => Expenses.Sum(exp => exp.Amount);
}
