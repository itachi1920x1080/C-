namespace InterfaceDemo;

//implementing to IOperator
public class Multiplication : IOperator
{
    public string Text { get; set; } = "Mul(*)";

    public double Operate(double a, double b) => a * b;
}

//implementing to IOperator
public class Subtraction : IOperator
{
    public string Text { get; set; } = "Sub(-)";

    public double Operate(double a, double b) => a - b;
}

//implementing to IOperator
public class Division : IOperator
{
    public string Text { get; set; } = "Div(/)";

    public double Operate(double a, double b) => a / b;
}