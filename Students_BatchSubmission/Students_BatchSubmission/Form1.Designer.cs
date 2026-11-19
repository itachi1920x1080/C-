namespace Students_BatchSubmission
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
            dgvStu = new DataGridView();
            groupBox1 = new GroupBox();
            btnAction = new Button();
            txtAge = new TextBox();
            label4 = new Label();
            cboGender = new ComboBox();
            label3 = new Label();
            txtFname = new TextBox();
            label2 = new Label();
            txtLname = new TextBox();
            label1 = new Label();
            chkMod = new CheckBox();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStu).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStu
            // 
            dgvStu.AllowUserToAddRows = false;
            dgvStu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStu.Location = new Point(23, 48);
            dgvStu.Name = "dgvStu";
            dgvStu.ReadOnly = true;
            dgvStu.RowHeadersWidth = 51;
            dgvStu.Size = new Size(554, 278);
            dgvStu.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAction);
            groupBox1.Controls.Add(txtAge);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboGender);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFname);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtLname);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(chkMod);
            groupBox1.Location = new Point(611, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 292);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Entry";
            // 
            // btnAction
            // 
            btnAction.Location = new Point(100, 233);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(124, 29);
            btnAction.TabIndex = 9;
            btnAction.Text = "Action";
            btnAction.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(100, 196);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 8;
            txtAge.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 197);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 7;
            label4.Text = "Age";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(100, 152);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(126, 28);
            cboGender.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 153);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 5;
            label3.Text = "Gender";
            // 
            // txtFname
            // 
            txtFname.Location = new Point(101, 111);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(125, 27);
            txtFname.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 112);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 3;
            label2.Text = "First Name";
            // 
            // txtLname
            // 
            txtLname.Location = new Point(101, 70);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(125, 27);
            txtLname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 71);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Last Name";
            // 
            // chkMod
            // 
            chkMod.AutoSize = true;
            chkMod.Location = new Point(15, 29);
            chkMod.Name = "chkMod";
            chkMod.Size = new Size(116, 24);
            chkMod.TabIndex = 0;
            chkMod.Text = "Modification";
            chkMod.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(418, 13);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 450);
            Controls.Add(btnSubmit);
            Controls.Add(groupBox1);
            Controls.Add(dgvStu);
            Name = "Form1";
            Text = "Students (Batch Submission)";
            ((System.ComponentModel.ISupportInitialize)dgvStu).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStu;
        private GroupBox groupBox1;
        private Button btnAction;
        private TextBox txtAge;
        private Label label4;
        private ComboBox cboGender;
        private Label label3;
        private TextBox txtFname;
        private Label label2;
        private TextBox txtLname;
        private Label label1;
        private CheckBox chkMod;
        private Button btnSubmit;
    }
}
