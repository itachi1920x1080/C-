namespace InterfaceDemo
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
            label1 = new Label();
            txtOpd1 = new TextBox();
            txtOpd2 = new TextBox();
            label2 = new Label();
            txtResult = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cboOp = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Operand 1";
            // 
            // txtOpd1
            // 
            txtOpd1.Location = new Point(97, 20);
            txtOpd1.Name = "txtOpd1";
            txtOpd1.Size = new Size(100, 23);
            txtOpd1.TabIndex = 1;
            txtOpd1.TextAlign = HorizontalAlignment.Right;
            // 
            // txtOpd2
            // 
            txtOpd2.Location = new Point(97, 60);
            txtOpd2.Name = "txtOpd2";
            txtOpd2.Size = new Size(100, 23);
            txtOpd2.TabIndex = 3;
            txtOpd2.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Operand 2";
            // 
            // txtResult
            // 
            txtResult.Location = new Point(97, 130);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(100, 23);
            txtResult.TabIndex = 5;
            txtResult.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Result";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 92);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Opeator";
            // 
            // cboOp
            // 
            cboOp.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOp.FormattingEnabled = true;
            cboOp.Location = new Point(98, 95);
            cboOp.Name = "cboOp";
            cboOp.Size = new Size(99, 23);
            cboOp.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(221, 177);
            Controls.Add(cboOp);
            Controls.Add(label4);
            Controls.Add(txtResult);
            Controls.Add(label3);
            Controls.Add(txtOpd2);
            Controls.Add(label2);
            Controls.Add(txtOpd1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtOpd1;
        private TextBox txtOpd2;
        private Label label2;
        private TextBox txtResult;
        private Label label3;
        private Label label4;
        private ComboBox cboOp;
    }
}
