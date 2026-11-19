namespace BatchSubmission_Student_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvStudents = new DataGridView();
            groupBox1 = new GroupBox();
            textboxid = new TextBox();
            label1 = new Label();
            textBox4 = new TextBox();
            firstname = new Label();
            add = new Button();
            age = new Label();
            textBox3 = new TextBox();
            gender = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lastname = new Label();
            modification = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(12, 55);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(416, 259);
            dgvStudents.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textboxid);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(firstname);
            groupBox1.Controls.Add(add);
            groupBox1.Controls.Add(age);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(gender);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lastname);
            groupBox1.Controls.Add(modification);
            groupBox1.Location = new Point(503, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(245, 369);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // textboxid
            // 
            textboxid.Location = new Point(92, 63);
            textboxid.Name = "textboxid";
            textboxid.Size = new Size(120, 23);
            textboxid.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 71);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 13;
            label1.Text = "ID";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(92, 226);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(120, 23);
            textBox4.TabIndex = 12;
            // 
            // firstname
            // 
            firstname.AutoSize = true;
            firstname.Location = new Point(11, 144);
            firstname.Name = "firstname";
            firstname.Size = new Size(64, 15);
            firstname.TabIndex = 11;
            firstname.Text = "First Name";
            // 
            // add
            // 
            add.Location = new Point(113, 289);
            add.Name = "add";
            add.Size = new Size(75, 23);
            add.TabIndex = 10;
            add.Text = "Add/Update";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // age
            // 
            age.AutoSize = true;
            age.Location = new Point(11, 234);
            age.Name = "age";
            age.Size = new Size(28, 15);
            age.TabIndex = 9;
            age.Text = "Age";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(92, 180);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(120, 23);
            textBox3.TabIndex = 8;
            // 
            // gender
            // 
            gender.AutoSize = true;
            gender.Location = new Point(11, 183);
            gender.Name = "gender";
            gender.Size = new Size(44, 15);
            gender.TabIndex = 7;
            gender.Text = "gender";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(92, 141);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(120, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 23);
            textBox1.TabIndex = 2;
            // 
            // lastname
            // 
            lastname.AutoSize = true;
            lastname.Location = new Point(11, 110);
            lastname.Name = "lastname";
            lastname.Size = new Size(63, 15);
            lastname.TabIndex = 1;
            lastname.Text = "Last Name";
            // 
            // modification
            // 
            modification.AutoSize = true;
            modification.Location = new Point(11, 22);
            modification.Name = "modification";
            modification.Size = new Size(94, 19);
            modification.TabIndex = 0;
            modification.Text = "Modification";
            modification.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvStudents);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStudents;
        private GroupBox groupBox1;
        private Label lastname;
        private CheckBox modification;
        private Button add;
        private Label age;
        private TextBox textBox3;
        private Label gender;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label firstname;
        private TextBox textboxid;
        private Label label1;
    }
}
