namespace ExpenseManagement
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
            components = new System.ComponentModel.Container();
            btnUpdate = new Button();
            btnCancel = new Button();
            txtDescr = new TextBox();
            label3 = new Label();
            txtAmount = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            label1 = new Label();
            errPro = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errPro).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(177, 127);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 22);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(82, 10);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtDescr
            // 
            txtDescr.Location = new Point(80, 102);
            txtDescr.Margin = new Padding(3, 2, 3, 2);
            txtDescr.Name = "txtDescr";
            txtDescr.Size = new Size(179, 23);
            txtDescr.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 12;
            label3.Text = "Descr";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(80, 70);
            txtAmount.Margin = new Padding(3, 2, 3, 2);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(110, 23);
            txtAmount.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 10;
            label2.Text = "Amount";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(80, 36);
            txtCode.Margin = new Padding(3, 2, 3, 2);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(110, 23);
            txtCode.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 8;
            label1.Text = "Code";
            // 
            // errPro
            // 
            errPro.ContainerControl = this;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 162);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(txtDescr);
            Controls.Add(label3);
            Controls.Add(txtAmount);
            Controls.Add(label2);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            Text = "Editing";
            Load += EditForm_Load;
            ((System.ComponentModel.ISupportInitialize)errPro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private Button btnCancel;
        private TextBox txtDescr;
        private Label label3;
        private TextBox txtAmount;
        private Label label2;
        private TextBox txtCode;
        private Label label1;
        private ErrorProvider errPro;
    }
}