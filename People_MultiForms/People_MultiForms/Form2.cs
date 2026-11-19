using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }

    // ==========================================
    // 1. PUBLIC PROPERTIES (To send data to Form1)
    // ==========================================
    public string PersonName
    {
        get { return txtName.Text; }
    }

    public string PersonGender
    {
        get { return cboGender.Text; }
    }

    public string PersonAge
    {
        get { return txtAge.Text; }
    }

    // ==========================================
    // 2. BUTTON EVENTS (Logic)
    // ==========================================

    // The "Create" Button Logic
    private void btnCreate_Click(object sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
        {
            MessageBox.Show("Input name ", "Adding",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
        }
        if (!byte.TryParse(txtAge.Text,out var age))
        {
            MessageBox.Show("Input age ","Adding",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
        }
        string gender = cboGender.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(gender) || !Enum.TryParse(gender,true ,out Gender genders))
        {
            MessageBox.Show("select gender .", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var person = new Person(name, genders, age);
        string filePath = Path.Combine(Application.StartupPath, "people.txt");
        string lineToWrite = $"{person.Name}/{person.Gender}/{person.Age}";
        File.AppendAllText(filePath, lineToWrite + Environment.NewLine);

       this.DialogResult = DialogResult.OK;
         this.Close();
    }

    // The "Clear" Button Logic
    private void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Clear(); // Clear Name
        txtAge.Clear(); // Clear Age
        cboGender.SelectedIndex = -1; // Reset Gender
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        // Optional: Set default gender to Male
        cboGender.SelectedIndex = 0;
    }

    // ==========================================
    // 3. GUI SETUP (Your existing code + Event Wiring)
    // ==========================================
    private void InitializeComponent()
    {
        txtAge = new TextBox();
        label3 = new Label();
        txtName = new TextBox();
        label4 = new Label();
        button1 = new Button();
        button2 = new Button();
        cboGender = new ComboBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // txtAge
        // 
        txtAge.Location = new Point(467, 131);
        txtAge.Name = "txtAge";
        txtAge.Size = new Size(51, 23);
        txtAge.TabIndex = 7;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(433, 139);
        label3.Name = "label3";
        label3.Size = new Size(28, 15);
        label3.TabIndex = 6;
        label3.Text = "Age";
        // 
        // txtName
        // 
        txtName.Location = new Point(95, 131);
        txtName.Name = "txtName";
        txtName.Size = new Size(127, 23);
        txtName.TabIndex = 5;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(50, 131);
        label4.Name = "label4";
        label4.Size = new Size(39, 15);
        label4.TabIndex = 4;
        label4.Text = "Name";
        // 
        // button1
        // 
        button1.Location = new Point(95, 59);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 8;
        button1.Text = "Clear";
        button1.UseVisualStyleBackColor = true;
        button1.Click += btnClear_Click;
        // 
        // button2
        // 
        button2.Location = new Point(443, 59);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 9;
        button2.Text = "Create";
        button2.UseVisualStyleBackColor = true;
        button2.Click += btnCreate_Click;
        // 
        // cboGender
        // 
        cboGender.FormattingEnabled = true;
        cboGender.Items.AddRange(new object[] { "Male", "Female" });
        cboGender.Location = new Point(298, 131);
        cboGender.Name = "cboGender";
        cboGender.Size = new Size(121, 23);
        cboGender.TabIndex = 10;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(247, 139);
        label1.Name = "label1";
        label1.Size = new Size(45, 15);
        label1.TabIndex = 11;
        label1.Text = "Gender";
        // 
        // CreateForm
        // 
        ClientSize = new Size(559, 204);
        Controls.Add(label1);
        Controls.Add(cboGender);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(txtAge);
        Controls.Add(label3);
        Controls.Add(txtName);
        Controls.Add(label4);
        Name = "CreateForm";
        Load += Form2_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    internal void SetData(string currentName, string currentGender, string currentAge)
    {
        throw new NotImplementedException();
    }

    private TextBox txtAge; // Age
    private Label label3;
    private TextBox txtName; // Name
    private Button button1;   // Clear
    private Button button2;   // Create
    private ComboBox cboGender; // Gender
    private Label label1;
    private Label label4;
}