namespace InterfaceDemo;

//Implementing to IOperator
public class Addition : IOperator
{
    public string Text { get; set; } = "Add(+)";

    public double Operate(double a, double b) => a + b;
}
