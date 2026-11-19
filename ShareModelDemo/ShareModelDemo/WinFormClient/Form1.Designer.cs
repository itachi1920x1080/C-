namespace WinFormClient
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
            btnFetch = new Button();
            dgvPrds = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPrds).BeginInit();
            SuspendLayout();
            // 
            // btnFetch
            // 
            btnFetch.Location = new Point(26, 24);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(94, 71);
            btnFetch.TabIndex = 0;
            btnFetch.Text = "Fetch Products";
            btnFetch.UseVisualStyleBackColor = true;
            // 
            // dgvPrds
            // 
            dgvPrds.AllowUserToAddRows = false;
            dgvPrds.AllowUserToDeleteRows = false;
            dgvPrds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrds.Location = new Point(142, 26);
            dgvPrds.Name = "dgvPrds";
            dgvPrds.ReadOnly = true;
            dgvPrds.RowHeadersWidth = 51;
            dgvPrds.Size = new Size(605, 398);
            dgvPrds.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPrds);
            Controls.Add(btnFetch);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)dgvPrds).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnFetch;
        private DataGridView dgvPrds;
    }
}
