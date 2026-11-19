
using People.Library;

namespace People.Reference;

public partial class EditForm : Form
{
    private string? _id;
    public EditForm(string? id)
    {
        InitializeComponent();
        cboGender.DataSource = Enum.GetValues<Gender>();
        _id = id;
        ViewEditPerson();
        btnCancel.Click += (sender, e) => ViewEditPerson();
        txtId.Leave += DoLeaveNo;
        btnUpdate.Click += DoClickUpdate;
    }

    private void DoClickUpdate(object? sender, EventArgs e)
    {
        List<string> errors = [];
        if (string.IsNullOrEmpty(txtName.Text.Trim())) errors.Add("Name is required");
        if (cboGender.SelectedIndex == -1) errors.Add("Gender is required");
        if (byte.TryParse(txtAge.Text, out byte age) == false) errors.Add($"Age,{txtAge.Text} is invalid");
        if (errors.Count > 0)
        {
            string msg = errors.Aggregate((a, b) => a + ", " + b);
            MessageBox.Show(msg, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        string inputId = txtId.Text.Trim();
        Person? edit = Program.PeopleMgr.GetPerson(inputId);
        if (edit == null)
        {
            MessageBox.Show($"Not found a person with id, {txtId.Text}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }
        _id = inputId;
        if (Program.PeopleMgr.Modify(_id, txtName.Text.Trim(), (Gender)cboGender.SelectedItem!, age) != null)
        {
            Task.Run(() => MessageBox.Show("Successfully updated", "Updating",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information));
        }
    }

    private void DoLeaveNo(object? sender, EventArgs e)
    {
        string inputId = txtId.Text.Trim();
        if (_id != inputId)
        {
            _id = inputId;
            ViewEditPerson();
        }
    }

    private void ViewEditPerson()
    {
        Person? edit = Program.PeopleMgr.GetPerson(_id??""); 
        txtId.Text = edit?.Id;
        txtName.Text = edit?.Name;
        cboGender.SelectedItem = edit?.Gender;
        txtAge.Text = edit?.Age.ToString();
    }
}
