namespace ExpenseManagement
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
            btnLoad = new Button();
            dgvExps = new DataGridView();
            btnSave = new Button();
            btnNew = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExps).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(20, 13);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(110, 22);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load Expenses";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dgvExps
            // 
            dgvExps.AllowUserToAddRows = false;
            dgvExps.AllowUserToDeleteRows = false;
            dgvExps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExps.Location = new Point(22, 41);
            dgvExps.Margin = new Padding(3, 2, 3, 2);
            dgvExps.Name = "dgvExps";
            dgvExps.ReadOnly = true;
            dgvExps.RowHeadersWidth = 51;
            dgvExps.Size = new Size(596, 260);
            dgvExps.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(402, 11);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 22);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Expenses";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(628, 76);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(82, 22);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(630, 145);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 22);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(630, 270);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(513, 13);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(105, 22);
            button1.TabIndex = 6;
            button1.Text = "Save Expenses As";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 316);
            Controls.Add(button1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(dgvExps);
            Controls.Add(btnLoad);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Expenses";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExps).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private DataGridView dgvExps;
        private Button btnSave;
        private Button btnNew;
        private Button btnEdit;
        private Button btnDelete;
        private Button button1;
    }
}
