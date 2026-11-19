using Shares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagement
{
    public partial class CreateForm : Form
    {
        public event EventHandler<Expense>? ExpenseCreated;
        public CreateForm()
        {
            InitializeComponent();
            btnClear.Click += (sender, e) =>
            {
                txtCode.Clear();
                txtAmount.Clear();
                txtDescr.Clear();
                errPro.Clear();
            };
            txtCode.Leave += (sender, e) =>
            {
                var inputCode = txtCode.Text.Trim();
                if (string.IsNullOrEmpty(inputCode)) return;
                if (Program.Expenses.Exists(e => e.Code.Equals(inputCode)))
                {
                    errPro.SetError(txtCode, $"The code, {inputCode}, does already exist");
                }
            };
            txtAmount.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(txtAmount.Text)) return;
                if (double.TryParse(txtAmount.Text, out var amount) == false)
                {
                    errPro.SetError(txtAmount, "Invalid amount");
                }
                if (amount < 0)
                {
                    errPro.SetError(txtAmount, "Amount is negative");
                }
            };
            txtCode.KeyPress += (sender, e) => { errPro.SetError(txtCode, ""); };
            txtAmount.KeyPress += (sender, e) => {errPro.SetError(txtAmount, ""); };
            btnCreate.Click += (sender, e) =>
            {
                var code = txtCode.Text.Trim();
                //Checking code
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show("Code is required", "Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var errCode = errPro.GetError(txtCode);
                if (string.IsNullOrEmpty(errCode)==false)
                {
                    MessageBox.Show(errCode, "Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //checking amount
                if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    MessageBox.Show("Amount is required", "Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var errAmount = errPro.GetError(txtAmount);
                if (string.IsNullOrEmpty(errAmount)==false)
                {
                    MessageBox.Show(errAmount, "Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //creating a new expense
                var exp = new Expense(code, double.Parse(txtAmount.Text), txtDescr.Text.Trim());
                Program.Expenses.Add(exp);
                ExpenseCreated?.Invoke(this, exp);
                MessageBox.Show("Successfully created");
                btnClear.PerformClick();
            };
        }

        
    }
}
