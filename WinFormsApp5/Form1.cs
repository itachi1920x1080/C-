using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private readonly string connString = "data source=10.4.13.30,14333\\teachingserver; initial catalog=enrolldb_m5; user id=sreng; password=123456; encrypt=false";
        public Form1()
        {
            InitializeComponent();
            TestConnection();

        }
        private void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection Successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void browse_Click(object sender, EventArgs e)

        {

            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM courses WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            textBox1.Text = reader["id"].ToString();
                            textBox2.Text = reader["code"].ToString();
                            textBox3.Text = reader["name"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            try
            {

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                string code = textBox2.Text;
                string name = textBox3.Text;
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    string sql = "update courses set code = @code, name = @name where id = @id";
                    //string sql = "INSERT INTO "
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
