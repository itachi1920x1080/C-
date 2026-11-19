using People.Library;

namespace People.Reference;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        ConfigGridView();
        Program.PeopleMgr.Added += (sender, per) => 
        { 
            AddPersonToView(per); 
            ViewOverallInfo(); 
        };
        Program.PeopleMgr.Removed += (sender, per) => 
        {
            dgvPers.Rows.Remove(per.Tag as DataGridViewRow);
            ViewOverallInfo();
            per.Tag = null;
        };
        Program.PeopleMgr.Updated += (sender, per) =>
        {
            var row = per.Tag as DataGridViewRow;
            row?.SetValues(per.Id, per.Name, per.Gender, per.Age);
        };

        btnReload.Click += (sender, e) => 
        {
            dgvPers.Rows.Clear();
            Program.PeopleMgr.Clear();
            Program.LoadedPeople.ForEach(p => Program.PeopleMgr.Add(p));
        };

        this.Shown += (sender, e) => { btnReload.PerformClick(); };
        btnDelete.Click += OnClickDelete;
        dgvPers.SelectionChanged += OnPersonSelectionChanged;
        btnNew.Click += (sender, e) => new CreateForm().Show();
        btnEdit.Click += OnClickEdit;
    }

    private void OnClickEdit(object? sender, EventArgs e)
    {
        string? id = "";
        
        if (dgvPers.CurrentRow != null)
        {
           id =dgvPers.CurrentRow.Cells["colId"].Value.ToString();
        }

        new EditForm(id).Show();
    }

    private void OnPersonSelectionChanged(object? sender, EventArgs e)
    {
        bool isEnabled = dgvPers.CurrentRow != null;
        btnDelete.Enabled = isEnabled;
        btnEdit.Enabled = isEnabled;    
    }

    private void OnClickDelete(object? sender, EventArgs e)
    {
        if (dgvPers.CurrentRow == null) return;
        Person? delPer= dgvPers.CurrentRow.Tag as Person;
        if (delPer == null) return;
 
        var result = MessageBox.Show($"Are you sure to delete a person named, {delPer.Name}?", "Deleting",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No) return;
        Program.PeopleMgr.Remove(delPer);
    }

    private void ConfigGridView()
    {
        dgvPers.Columns.Add("colId", "Id");
        dgvPers.Columns.Add("colName", "Name");
        dgvPers.Columns.Add("colGender", "Gender");
        dgvPers.Columns.Add("colAge", "Age");
        dgvPers.Columns["colAge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvPers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void AddPersonToView(Person per)
    {
        int index = dgvPers.Rows.Add(per.Id, per.Name, per.Gender, per.Age);
        var row = dgvPers.Rows[index];
        per.Tag = row;
        row.Tag = per;
    }
    private void ViewOverallInfo()
    {
        txtCount.Text = Program.PeopleMgr.Count.ToString();
        txtMaxAge.Text = Program.PeopleMgr.MaxAge?.ToString();
    }
}
