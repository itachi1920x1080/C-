using System;
using System.Drawing;
using System.Windows.Forms;

namespace People_MultiForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            // Setup button events
            Edit.Click += Edit_Click;       // The Save/Update button
            button1.Click += ButtonClear_Click; // The Clear button
        }

        // --- 1. PROPERTIES: Allow Form1 to get the data ---
        public string PersonName { get { return txtName.Text.Trim(); } }
        public string PersonGender { get { return cboGender.SelectedItem?.ToString(); } }
        public string PersonAge { get { return txtAge.Text.Trim(); } }

        // --- 2. SET DATA: Allow Form1 to fill the boxes for Editing ---
        public void SetData(string name, string gender, string age)
        {
            txtName.Text = name;
            cboGender.SelectedItem = gender;
            txtAge.Text = age;
            Edit.Text = "Update"; // Change button text visually
        }

        // --- 3. THE SAVE/EDIT BUTTON ---
        private void Edit_Click(object sender, EventArgs e)
        {
            // A. Validate Name
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please input Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // B. Validate Gender
            if (cboGender.SelectedItem == null)
            {
                MessageBox.Show("Please select a Gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // C. Validate Age
            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please input a valid Age (number).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // D. Success! 
            // We do NOT save to file here. We return OK.
            // Form1 will handle the saving (Append if Add, Replace if Edit).
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = -1;
            txtName.Focus();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            // Optional: Select first gender by default if adding new
            if (cboGender.SelectedIndex == -1)
                cboGender.SelectedIndex = 0;
        }

        // --- DESIGNER CODE ---
        private void InitializeComponent()
        {
            label1 = new Label();
            cboGender = new ComboBox();
            Edit = new Button();
            button1 = new Button();
            txtAge = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 192);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 19;
            label1.Text = "Gender";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Male", "Female" });
            cboGender.Location = new Point(84, 184);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(50, 23);
            cboGender.TabIndex = 18;
            // 
            // Edit
            // 
            Edit.Location = new Point(269, 83);
            Edit.Name = "Edit";
            Edit.Size = new Size(75, 23);
            Edit.TabIndex = 17;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(84, 83);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(217, 184);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(46, 23);
            txtAge.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 192);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 14;
            label3.Text = "Age";
            // 
            // txtName
            // 
            txtName.Location = new Point(84, 155);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 23);
            txtName.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 155);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 12;
            label4.Text = "Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 126);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(260, 23);
            textBox1.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 129);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 21;
            label2.Text = "ID";
            // 
            // CreateForm
            // 
            ClientSize = new Size(391, 247);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(cboGender);
            Controls.Add(Edit);
            Controls.Add(button1);
            Controls.Add(txtAge);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label4);
            Name = "CreateForm";
            Load += CreateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private ComboBox cboGender;
        private Button Edit;
        private Button button1;
        private TextBox txtAge;
        private Label label3;
        private TextBox txtName;
        private TextBox textBox1;
        private Label label2;
        private Label label4;

        private void Edit_Click_1(object sender, EventArgs e)
        {

        }
    }
}