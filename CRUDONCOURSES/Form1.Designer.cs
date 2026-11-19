namespace CRUDONCOURSES
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
            reltieve = new Button();
            create = new Button();
            edit = new Button();
            dataGridView1 = new DataGridView();
            detele = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // reltieve
            // 
            reltieve.Location = new Point(32, 31);
            reltieve.Name = "reltieve";
            reltieve.Size = new Size(75, 23);
            reltieve.TabIndex = 0;
            reltieve.Text = "Reltieve";
            reltieve.UseVisualStyleBackColor = true;
            reltieve.Click += button1_Click;
            // 
            // create
            // 
            create.Location = new Point(350, 31);
            create.Name = "create";
            create.Size = new Size(75, 23);
            create.TabIndex = 1;
            create.Text = "Create ";
            create.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            edit.Location = new Point(690, 31);
            edit.Name = "edit";
            edit.Size = new Size(75, 23);
            edit.TabIndex = 2;
            edit.Text = "Edit";
            edit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(733, 359);
            dataGridView1.TabIndex = 3;
            // 
            // detele
            // 
            detele.Location = new Point(690, 460);
            detele.Name = "detele";
            detele.Size = new Size(75, 23);
            detele.TabIndex = 4;
            detele.Text = "Detele";
            detele.UseVisualStyleBackColor = true;
            detele.Click += detele_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 521);
            Controls.Add(detele);
            Controls.Add(dataGridView1);
            Controls.Add(edit);
            Controls.Add(create);
            Controls.Add(reltieve);
            Name = "Form1";
            Text = "View Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button reltieve;
        private Button create;
        private Button edit;
        private DataGridView dataGridView1;
        private Button detele;
    }
}
