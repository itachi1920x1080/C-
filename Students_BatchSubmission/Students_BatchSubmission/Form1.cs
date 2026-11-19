using Microsoft.Data.SqlClient;
using System.Data;

namespace Students_BatchSubmission;

public partial class Form1 : Form
{
    string connStr = @"server=10.4.13.30,14333\teachingserver;
database=enrolldb_m5; uid=sreng; pwd=123456; encrypt=false";
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable tbl = new DataTable();
    BindingSource bs = new BindingSource();
    Gender[] genders = Enum.GetValues<Gender>();
    public Form1()
    {
        InitializeComponent();
        cboGender.DataSource = genders;

        da = new SqlDataAdapter("select * from students", connStr);
        da.Fill(tbl);

        tbl.Columns.Add("Name", typeof(string), "LastName + ' ' + FirstName");


        bs.DataSource = tbl;
        dgvStu.DataSource = bs;
        dgvStu.Columns["firstname"].Visible = false;
        dgvStu.Columns["lastname"].Visible = false;
        dgvStu.Columns["name"].DisplayIndex = 1;
        dgvStu.CellFormatting += (sender, e) =>
        {
            if (e.ColumnIndex != dgvStu.Columns["Gender"].Index) return;
            if (e.Value != null)
            {
                try
                {
                    int genderValue = Convert.ToInt32(e.Value);
                    e.Value = genders[genderValue].ToString();
                }
                catch (Exception) { }
            }
        };

        chkMod.CheckedChanged += (sender, e) =>
        {
            btnAction.Text = chkMod.Checked == false ? "Add" : "Update";
            DataRow? row = null;
            if (chkMod.Checked && bs.Current != null)
            {
                row = ((DataRowView)bs.Current).Row;
            }
            ViewRow(row);
        };

        chkMod.Checked = true;
        chkMod.Checked = false;
        cboGender.SelectedItem = null;

        btnSubmit.Click += (sender, e) =>
        {
            try
            {
                int n = da.Update(tbl);
                MessageBox.Show($"{n} record(s) affected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        };

        btnAction.Click += (sender, e) =>
        {
            DataRow row;

            if (chkMod.Checked)
            {
                if (bs.Current == null) return;
                row = ((DataRowView)bs.Current).Row;
                AssignRow(row);
            }
            else
            {
                row = tbl.NewRow();
                row["id"] = Guid.NewGuid().ToString();
                AssignRow(row);
                tbl.Rows.Add(row);
            }
            bs.ResetBindings(false);
        };

        bs.PositionChanged += (sender, e) =>
        {
            chkMod.Enabled = bs.Current != null;
            if (chkMod.Checked == false) return;
            DataRow? row = null;
            if (bs.Current != null)
                row = ((DataRowView)bs.Current).Row;
            ViewRow(row);
        };

        new SqlCommandBuilder(da);
    }
    private void ViewRow(DataRow? row)
    {
        txtFname.Text = row?["FirstName"].ToString() ?? "";
        txtLname.Text = row?["LastName"].ToString() ?? "";
        txtAge.Text = row?["age"].ToString() ?? "";
        if (row==null) 
            cboGender.SelectedItem = null;
        else
        {
            cboGender.SelectedItem = (row["gender"] == DBNull.Value ? null : genders[(int)row["gender"]]);
        }
            
    }
    private void AssignRow(DataRow row)
    {
        row["FirstName"] = txtFname.Text;
        row["LastName"] = txtLname.Text;
        row["age"] = byte.Parse(txtAge.Text);
        row["gender"] = (cboGender.SelectedItem == null ? DBNull.Value : Convert.ToInt32(cboGender.SelectedItem));
    }
}
public enum Gender
{
    Female = 0,
    Male = 1,
    Unknown = 2
}
