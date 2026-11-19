namespace People_MultiForms
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
            Reload_Click = new Button();
            Overall = new GroupBox();
            MaxAge = new TextBox();
            label2 = new Label();
            Count = new TextBox();
            label1 = new Label();
            dgvPers = new DataGridView();
            New = new Button();
            Add = new Button();
            Delete = new Button();
            Overall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPers).BeginInit();
            SuspendLayout();
            // 
            // Reload_Click
            // 
            Reload_Click.Location = new Point(12, 24);
            Reload_Click.Name = "Reload_Click";
            Reload_Click.Size = new Size(75, 23);
            Reload_Click.TabIndex = 0;
            Reload_Click.Text = "Roload";
            Reload_Click.UseVisualStyleBackColor = true;
            Reload_Click.Click += Reload_Click_Click;
            // 
            // Overall
            // 
            Overall.Controls.Add(MaxAge);
            Overall.Controls.Add(label2);
            Overall.Controls.Add(Count);
            Overall.Controls.Add(label1);
            Overall.Location = new Point(28, 69);
            Overall.Name = "Overall";
            Overall.Size = new Size(388, 100);
            Overall.TabIndex = 1;
            Overall.TabStop = false;
            Overall.Text = "Overrall";
            // 
            // MaxAge
            // 
            MaxAge.Location = new Point(216, 44);
            MaxAge.Name = "MaxAge";
            MaxAge.Size = new Size(63, 23);
            MaxAge.TabIndex = 3;
            MaxAge.TextChanged += MaxAge_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 52);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 2;
            label2.Text = "Max,Age";
            // 
            // Count
            // 
            Count.Location = new Point(50, 44);
            Count.Name = "Count";
            Count.Size = new Size(63, 23);
            Count.TabIndex = 1;
            Count.TextChanged += Count_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 52);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Count";
            // 
            // dgvPers
            // 
            dgvPers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPers.Location = new Point(28, 175);
            dgvPers.Name = "dgvPers";
            dgvPers.Size = new Size(554, 360);
            dgvPers.TabIndex = 2;
            dgvPers.CellContentClick += dgvPers_CellContentClick;
            // 
            // New
            // 
            New.Location = new Point(663, 196);
            New.Name = "New";
            New.Size = new Size(75, 23);
            New.TabIndex = 3;
            New.Text = "New";
            New.UseVisualStyleBackColor = true;
            New.Click += New_Click;
            // 
            // Add
            // 
            Add.Location = new Point(663, 271);
            Add.Name = "Add";
            Add.Size = new Size(75, 23);
            Add.TabIndex = 4;
            Add.Text = "Edit";
            Add.UseVisualStyleBackColor = true;
            Add.Click += update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(663, 512);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 5;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 572);
            Controls.Add(Delete);
            Controls.Add(Add);
            Controls.Add(New);
            Controls.Add(dgvPers);
            Controls.Add(Overall);
            Controls.Add(Reload_Click);
            Name = "Form1";
            Text = " People";
            Load += Form1_Load;
            Overall.ResumeLayout(false);
            Overall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Reload_Click;
        private GroupBox Overall;
        private TextBox MaxAge;
        private Label label2;
        private TextBox Count;
        private Label label1;
        private DataGridView dgvPers;
        private Button New;
        private Button Add;
        private Button Delete;
    }
}
