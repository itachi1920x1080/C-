using People.Library;

namespace People.Reference
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            cboGender.DataSource = Enum.GetValues<Gender>();

            btnClear.Click += (sender, e) =>
            {
                txtName.Clear();
                txtAge.Clear();
                cboGender.SelectedIndex = -1;
            };

            btnCreate.Click += DoClickCreate;
            this.Shown += (sender, e) => btnClear.PerformClick();
        }

        private void DoClickCreate(object? sender, EventArgs e)
        {
            List<string> errors = [];
            if (string.IsNullOrEmpty(txtName.Text.Trim())) errors.Add("Name is required");
            if (cboGender.SelectedIndex==-1) errors.Add("Gender is required");
            if (byte.TryParse(txtAge.Text, out byte age) == false) errors.Add($"Age,{txtAge.Text} is invalid");
            if (errors.Count > 0)
            {
                string msg = errors.Aggregate((a, b) => a + ", " + b);
                MessageBox.Show(msg, "Creating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
    
            string name = txtName.Text.Trim();
            Gender gender = (Gender)cboGender.SelectedItem!;
            Person newPer = new Person(name, gender, age);
            if (Program.PeopleMgr.Add(newPer))
                MessageBox.Show("Successfully created", "Creating", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
