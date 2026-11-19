namespace People.Reference
{
    partial class EditForm
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
            btnUpdate = new Button();
            cboGender = new ComboBox();
            txtAge = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            btnCancel = new Button();
            txtId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(326, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(82, 132);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(106, 28);
            cboGender.TabIndex = 19;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(253, 135);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(54, 27);
            txtAge.TabIndex = 18;
            txtAge.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(211, 135);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 17;
            label4.Text = "Age";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 135);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 16;
            label3.Text = "Gender";
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 89);
            txtName.Name = "txtName";
            txtName.Size = new Size(338, 27);
            txtName.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 96);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 14;
            label2.Text = "Name";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(82, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Location = new Point(82, 54);
            txtId.Name = "txtId";
            txtId.Size = new Size(338, 27);
            txtId.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 57);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 11;
            label1.Text = "Id";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 174);
            Controls.Add(btnUpdate);
            Controls.Add(cboGender);
            Controls.Add(txtAge);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(txtId);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            Text = "Editing People";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private ComboBox cboGender;
        private TextBox txtAge;
        private Label label4;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private Button btnCancel;
        private TextBox txtId;
        private Label label1;
    }
}