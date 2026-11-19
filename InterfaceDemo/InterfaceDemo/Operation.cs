namespace InterfaceDemo;

//client of IOperator
class Operation
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    public IOperator Operator { get; set; } = default!;
    public double Result => Operator.Operate(Operand1, Operand2);
}