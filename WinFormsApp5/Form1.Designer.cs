namespace WinFormsApp5
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            Id = new Label();
            code = new Label();
            name = new Label();
            browse = new Button();
            cancel = new Button();
            submit = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(210, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(268, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(210, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(259, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(210, 196);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(259, 23);
            textBox3.TabIndex = 2;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(136, 54);
            Id.Name = "Id";
            Id.Size = new Size(18, 15);
            Id.TabIndex = 3;
            Id.Text = "ID";
            // 
            // code
            // 
            code.AutoSize = true;
            code.Location = new Point(138, 132);
            code.Name = "code";
            code.Size = new Size(35, 15);
            code.TabIndex = 4;
            code.Text = "Code";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(131, 204);
            name.Name = "name";
            name.Size = new Size(42, 15);
            name.TabIndex = 5;
            name.Text = "Name ";
            // 
            // browse
            // 
            browse.Location = new Point(556, 54);
            browse.Name = "browse";
            browse.Size = new Size(75, 23);
            browse.TabIndex = 6;
            browse.Text = "Browse";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(556, 132);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 7;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // submit
            // 
            submit.Location = new Point(556, 200);
            submit.Name = "submit";
            submit.Size = new Size(75, 23);
            submit.TabIndex = 8;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Click += submit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(submit);
            Controls.Add(cancel);
            Controls.Add(browse);
            Controls.Add(name);
            Controls.Add(code);
            Controls.Add(Id);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label Id;
        private Label code;
        private Label name;
        private Button browse;
        private Button cancel;
        private Button submit;
    }
}
