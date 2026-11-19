namespace People.Reference
{
    partial class CreateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClear = new Button();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtAge = new TextBox();
            label4 = new Label();
            cboGender = new ComboBox();
            btnCreate = new Button();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(29, 23);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(29, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(249, 27);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 55);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(282, 55);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 5;
            label3.Text = "Gender";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(394, 79);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(54, 27);
            txtAge.TabIndex = 4;
            txtAge.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(394, 55);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 7;
            label4.Text = "Age";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(282, 78);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(106, 28);
            cboGender.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(354, 23);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 137);
            Controls.Add(btnCreate);
            Controls.Add(cboGender);
            Controls.Add(txtAge);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(btnClear);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateForm";
            Text = "Creating People";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClear;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private TextBox txtAge;
        private Label label4;
        private ComboBox cboGender;
        private Button btnCreate;
    }
}