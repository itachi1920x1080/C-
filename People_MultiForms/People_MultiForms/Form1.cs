
using System;
using System.IO;
using System.Windows.Forms;
using ProductLib
namespace People_MultiForms
{
    public partial class Form1 : Form
    {
        private object id;

        public Form1()
        {
            InitializeComponent();
            ConfigView();
            LoadPeople();
            Reload_Click.Click += Reload_Click_Click;

        }

        private void ConfigView()
        {

            dgvPers.AllowUserToAddRows = false;
            dgvPers.ReadOnly = true;

            dgvPers.Columns.Add("ID", "ID");
            dgvPers.Columns.Add("Name", "Name");
            dgvPers.Columns.Add("Gender", "Gender");
            dgvPers.Columns.Add("Age", "Age");
            dgvPers.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        private void dgvpers_selectrow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header row

            DataGridViewRow row = dgvPers.Rows[e.RowIndex];
            if (row == null || row.IsNewRow) return;

            //txtName.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
            //genderup.SelectedItem = row.Cells[1].Value?.ToString() ?? string.Empty;
            //ageup.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
        }


        private void Reload_Click_Click(object sender, EventArgs e)
        {
            dgvPers.Rows.Clear();
            LoadPeople();

        }

        private void LoadPeople()
        {
            string filePath = Path.Combine(Application.StartupPath, "people.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("people.txt not found!");
                return;
            }

            int id = 1;

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('/'); //"," error here

                if (parts.Length == 3)
                {
                    dgvPers.Rows.Add(id, parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                    id++;
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvPers.Rows.Clear();
                LoadPeople();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dgvPers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select  a row .");
                return;
            }

            DialogResult re = MessageBox.Show("Are you delete this person ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (re == DialogResult.No) return;

            DataGridViewRow row = dgvPers.SelectedRows[0];
            dgvPers.Rows.Remove(row);

            string filePath = Path.Combine(Application.StartupPath, "people.txt");
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (DataGridViewRow r in dgvPers.Rows)
                {
                    if (!r.IsNewRow && r.Cells.Count >= 3)
                    {
                        string name = r.Cells["Name"].Value?.ToString() ?? "";
                        string gender = r.Cells["Gender"].Value?.ToString() ?? "";
                        string age = r.Cells["Age"].Value?.ToString() ?? "";

                        sw.WriteLine($"{name}/{gender}/{age}");
                    }
                }
            }
            MessageBox.Show("Row deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (dgvPers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            DataGridViewRow row = dgvPers.SelectedRows[0];


            string currentName = row.Cells[1].Value?.ToString() ?? "";
            string currentGender = row.Cells[2].Value?.ToString() ?? "";
            string currentAge = row.Cells[3].Value?.ToString() ?? "";

            Form3 frm = new Form3();
            frm.SetData(currentName, currentGender, currentAge);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                row.Cells[1].Value = frm.PersonName;
                row.Cells[2].Value = frm.PersonGender;
                row.Cells[3].Value = frm.PersonAge;

                string filePath = Path.Combine(Application.StartupPath, "people.txt");

                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (DataGridViewRow r in dgvPers.Rows)
                    {
                        if (!r.IsNewRow)
                        {
                            string v1 = r.Cells[1].Value?.ToString() ?? ""; // Name
                            string v2 = r.Cells[2].Value?.ToString() ?? ""; // Gender
                            string v3 = r.Cells[3].Value?.ToString() ?? ""; // Age

                            sw.WriteLine($"{v1}/{v2}/{v3}");
                        }
                    }
                }

                MessageBox.Show("Update Successful", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Count_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "people.txt");
            if (!File.Exists(filePath))
            {
                MessageBox.Show("people.txt not found!");
                return;
            }
            //int id = 1;
            dgvPers.Rows.Clear();
            int counter = 1;
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('/');

                if (parts.Length == 3)
                {
                    // Use 'counter' here
                    dgvPers.Rows.Add(counter, parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                    counter++;
                }
            }
            MessageBox.Show($"Total people: {counter - 1}", "Count", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void MaxAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
