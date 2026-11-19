using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        List<Expense> exps = new List<Expense>
        {
            new Expense { code = 1, Amount = 100.50, Descr = "Nikotin" },
            new Expense { code = 2, Amount = 250.00, Descr = "k" },
            new Expense { code = 3, Amount = 2999.00, Descr = "YAMA " }
        };
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bs.DataSource = exps;
            dataGridView1.DataSource = bs;
            comboBox1.Items.AddRange(new string[] { "Code", "Amount ", "Descr" });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chose = comboBox1.SelectedItem.ToString();
            switch (chose)
            {
                case "Code":
                    exps.Sort(new codecomparer());
                    break;
                case "Amount":
                    exps.Sort(new Amountcomparer());
                    break;
                case "Descr":
                    exps.Sort(new Descrcomparer());
                    break;
            }
            bs.ResetBindings(false);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)

        {
            double total = exps.Sum(x => x.Amount);

            textBox1.Text = total.ToString("N2");
            bs.ResetBindings(false);
        }
    }
}
