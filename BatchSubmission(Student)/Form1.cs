using Microsoft.Data.SqlClient;
using System.Data;
namespace BatchSubmission_Student_
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            Test_db();
            LoadData(GetDgvStudents1());
        }
        private void Test_db()
        {
            string connString = "data source=10.4.13.30,14333\\teachingserver; initial catalog=enrolldb_m5; user id=sreng; password=123456; encrypt=false";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("Connection opened successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private SqlConnection GetConnection()
        {
            string connString = "data source=10.4.13.30,14333\\teachingserver; initial catalog=enrolldb_m5; user id=sreng; password=123456; encrypt=false";
            return new SqlConnection(connString);
        }

        private DataGridView GetDgvStudents1()
        {
            return dgvStudents;
        }

        private void LoadData(DataGridView dgvStudents1)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string query = "SELECT id, lastname, firstname,CASE WHEN gender = '0' THEN 'Female' ELSE 'Male' END as gender,age FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    dgvStudents1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }




        private void add_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                  { 
                    string lastname = textBox1.Text;
                    string firstname = textBox2.Text;
                    string gender = textBox3.Text;
                    string age = textBox4.Text;
                    string id = textboxid.Text;
                    string qury = "INSERT INTO Students  (id,lastname,firstname,gender,age)" +
                                  "VALUES (@id,@lastname,@firstname,@gender,@age)";
                    using (SqlCommand cmd = new SqlCommand(qury, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@gender",int.Parse( gender));
                        cmd.Parameters.AddWithValue("@age",int.Parse( age));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student added successfully!");
                        LoadData(GetDgvStudents1());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add student: " + ex.Message);
                }

            }
        }

        private void delete_click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["id"].Value);
                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        string query = "DELETE FROM Students WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Student deleted successfully!");
                            LoadData(GetDgvStudents1());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete student: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}