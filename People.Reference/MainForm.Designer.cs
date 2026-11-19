namespace People.Reference
{
    partial class MainForm
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
            groupBox1 = new GroupBox();
            txtMaxAge = new TextBox();
            label2 = new Label();
            txtCount = new TextBox();
            label1 = new Label();
            dgvPers = new DataGridView();
            btnDelete = new Button();
            btnNew = new Button();
            btnEdit = new Button();
            btnReload = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPers).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMaxAge);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCount);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(332, 67);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Overall";
            // 
            // txtMaxAge
            // 
            txtMaxAge.Location = new Point(253, 26);
            txtMaxAge.Name = "txtMaxAge";
            txtMaxAge.ReadOnly = true;
            txtMaxAge.Size = new Size(61, 27);
            txtMaxAge.TabIndex = 3;
            txtMaxAge.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 29);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 2;
            label2.Text = "Max. Age";
            // 
            // txtCount
            // 
            txtCount.Location = new Point(83, 26);
            txtCount.Name = "txtCount";
            txtCount.ReadOnly = true;
            txtCount.Size = new Size(61, 27);
            txtCount.TabIndex = 1;
            txtCount.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 0;
            label1.Text = "Count";
            // 
            // dgvPers
            // 
            dgvPers.AllowUserToAddRows = false;
            dgvPers.AllowUserToDeleteRows = false;
            dgvPers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPers.Location = new Point(12, 133);
            dgvPers.Name = "dgvPers";
            dgvPers.ReadOnly = true;
            dgvPers.RowHeadersWidth = 51;
            dgvPers.Size = new Size(766, 344);
            dgvPers.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(784, 448);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(798, 151);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(798, 195);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(18, 16);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 0;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 500);
            Controls.Add(btnReload);
            Controls.Add(btnEdit);
            Controls.Add(btnNew);
            Controls.Add(btnDelete);
            Controls.Add(dgvPers);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "People";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtMaxAge;
        private Label label2;
        private TextBox txtCount;
        private Label label1;
        private DataGridView dgvPers;
        private Button btnDelete;
        private Button btnNew;
        private Button btnEdit;
        private Button btnReload;
    }
}
