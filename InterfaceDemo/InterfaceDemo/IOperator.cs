namespace InterfaceDemo;

public interface IOperator
{
    string Text { get; set; }
    double Operate(double a, double b);
}
