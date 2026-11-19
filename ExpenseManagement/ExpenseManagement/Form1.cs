using Shares;
using System.Text.Json;
using System.IO;

namespace ExpenseManagement
{
    public partial class Form1 : Form
    {
        private BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.DataSource = Program.Expenses;
            dgvExps.DataSource = bs;

            btnNew.Click += (sender, e) =>
            {
                var frm = new CreateForm();
                frm.ExpenseCreated += (sender, e) => { bs.ResetBindings(false); };
                frm.Show();
            };

            btnEdit.Click += (sender, e) =>
            {
                var exp = (bs.Current as Expense);
                var frm = new EditForm(exp);
                frm.ExpenseUpdated += (sender, e) => { bs.ResetBindings(false); };
                frm.Show();
            };

            btnDelete.Click += (sender, e) =>
            {
                if (bs.Current == null) return;
                bs.RemoveCurrent();
                bs.ResetBindings(false);
            };


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }



        private void DDD()
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.InitialDirectory = Application.StartupPath;
                openfile.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openfile.Title = "ជ្រើសរើសឯកសារទិន្នន័យចំណាយ";

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(openfile.FileName);
                        var exps = JsonSerializer.Deserialize<List<Expense>>(jsonContent);

                        if (exps != null)
                        {
                            Program.Expenses.Clear();
                            foreach (var item in exps)
                            {
                                Program.Expenses.Add(item);
                            }

                            // ធ្វើបច្ចុប្បន្នភាព UI
                            bs.ResetBindings(false);

                            MessageBox.Show("ទាញយកទិន្នន័យបានជោគជ័យ!", "ជោគជ័យ",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"មិនអាចអានឯកសារបានទេ: {ex.Message}", "កំហុស",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Define the file path (saves in the same folder as the .exe)
                string filePath = "expenses.json";

                // Serialize the list to a formatted JSON string
                string jsonString = JsonSerializer.Serialize(Program.Expenses, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // Write to the file
                File.WriteAllText(filePath, jsonString);

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                // កំណត់ Filter ឱ្យបង្ហាញតែឯកសារ .json
                saveFile.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFile.Title = "រក្សាទុកទិន្នន័យជា JSON";
                saveFile.DefaultExt = "json";
                saveFile.FileName = "expenses.json"; // ឈ្មោះឯកសារលំនាំដើម

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // កំណត់ឱ្យ JSON ចុះបន្ទាត់ស្អាត (ងាយស្រួលអាន)
                        var options = new JsonSerializerOptions { WriteIndented = true };

                        // បំប្លែង List ទៅជាអត្ថបទ JSON
                        string jsonString = JsonSerializer.Serialize(Program.Expenses, options);

                        // សរសេរចូលក្នុងឯកសារ
                        File.WriteAllText(saveFile.FileName, jsonString);

                        MessageBox.Show("រក្សាទុកជា JSON បានជោគជ័យ!", "ជោគជ័យ",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"មានបញ្ហាក្នុងការរក្សាទុក: {ex.Message}", "កំហុស");
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvExps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExps.MultiSelect = false;
            DDD();
        }
    }

}
