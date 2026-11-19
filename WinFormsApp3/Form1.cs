
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private List<Expense> expenseseBag = new List<Expense>();

        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)

        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                expenseseBag.Add(new Expense
                {
                    Generator = "A",
                    Amount = rand.Next(1, 1001),
                    Time = DateTime.Now.AddMinutes(-i)
                });

            }
            UpdateUI();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                expenseseBag.Add(new Expense
                {
                    Generator = "B",
                    Amount = 1000,
                    Time = DateTime.Now.AddMinutes(-i)
                });

            }
            UpdateUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                expenseseBag.Add(new Expense
                {
                    Generator = "C",
                    Amount = 1000,
                    Time = DateTime.Now.AddMinutes(-i)
                });

            }
            UpdateUI();
        }
        private void UpdateUI()
        {
            comboBoxExpenses.DataSource = null;
            comboBoxExpenses.DataSource = expenseseBag;
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            expenseseBag.Clear();
            UpdateUI();
        }
    }
}
