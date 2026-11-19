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
    public partial class EditForm : Form
    {
        Expense? curExp;
        public event EventHandler<Expense>? ExpenseUpdated;
        public EditForm(Expense? exp = null)
        {
            InitializeComponent();
            curExp = exp;

            btnCancel.Click += (sender, e) => { ViewExpense(); };
            txtCode.Leave += (sender, e) =>
            {
                var inputCode = txtCode.Text.Trim();
                var found = Program.Expenses.FirstOrDefault(x => x.Code == inputCode);
                txtAmount.ReadOnly = (found == null);
                txtDescr.ReadOnly = (found == null);
                errPro.SetError(txtCode, found == null ? "Not found" : "");
                if (found != null)
                {
                    txtAmount.Text = found.Amount.ToString();
                    txtDescr.Text = found.Descr;
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
            txtAmount.KeyPress += (sender, e) => { errPro.SetError(txtAmount, ""); };

            btnUpdate.Click += (sender, e) =>
            {
                var errCode = errPro.GetError(txtCode);
                //checking code
                if (string.IsNullOrEmpty(errCode) == false)
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
                if (string.IsNullOrEmpty(errAmount) == false)
                {
                    MessageBox.Show(errAmount, "Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //updating an existing expense
                var code = txtCode.Text.Trim();
                var found = Program.Expenses.FirstOrDefault(e => e.Code == code);
                if (found == null)
                {
                    MessageBox.Show($"No expense with code, {code}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                found.Amount = double.Parse(txtAmount.Text.Trim());
                found.Descr = txtDescr.Text.Trim();
                ExpenseUpdated?.Invoke(this, found);
                MessageBox.Show("Successfully updated");
                curExp = found;
                ViewExpense();
            };
            ViewExpense();
        }
        void ViewExpense()
        {
            txtCode.Text = curExp?.Code;
            txtAmount.Text = curExp?.Amount.ToString();
            txtDescr.Text = curExp?.Descr;
            errPro.Clear();
            txtAmount.ReadOnly = (curExp == null);
            txtDescr.ReadOnly = (curExp == null);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
