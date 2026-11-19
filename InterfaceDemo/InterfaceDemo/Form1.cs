using System.Numerics;

namespace InterfaceDemo;

public partial class Form1 : Form
{
    Operation op = new Operation()
    {
        Operand1 = 50,
        Operand2 = 2,
    };
    List<IOperator> ops = [
            new Addition(){Text="បូក"},
            new Subtraction(),
            new Multiplication(),
            new Division()
        ];
    BindingSource bs = new BindingSource();
    public Form1()
    {
        InitializeComponent();
        bs.DataSource = op;

        txtOpd1.DataBindings.Add("Text", bs, "Operand1");
        txtOpd2.DataBindings.Add("Text", bs, "Operand2");

        cboOp.SelectedValueChanged += (_, _)=>
        {
            op.Operator = (cboOp.SelectedItem as IOperator)!;
            bs.ResetBindings(false);
        };
        cboOp.DataSource = ops;
        cboOp.DisplayMember = "Text";

        txtResult.DataBindings.Add("Text", bs, "Result");
    }
}
