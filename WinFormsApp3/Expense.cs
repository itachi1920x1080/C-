public class Expense
{
    public string Generator { get; set; } 
    public double Amount { get; set; }
    public DateTime Time { get; set; }   

    public override string ToString()
    {
        return $"{Generator} : ${Amount} ({Time.ToShortDateString()})";
    }
}