using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        List<Expense> exps = new List<Expense>
        {
            new Expense { NO = 1, Amount = 100.50, Branch = "Nikotin" },
            new Expense { NO = 2, Amount = 250.00, Branch = "k" },
            new Expense { NO = 3, Amount = 2999.00, Branch = "YAMA" }
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

            var branchNames = exps.Select(x => x.Branch).Distinct().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(branchNames);
        }



        public class Expense
        {
            public int NO { get; set; }
            public double Amount { get; set; }
            public required string Branch { get; set; }

        }
        
       
    }
}
