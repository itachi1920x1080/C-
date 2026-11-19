using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDONCOURSES
{
    public partial class Form1 : Form
    {

        private readonly string connString = "data source=10.4.13.30,14333\\teachingserver; initial catalog=enrolldb_m6; user id=sreng; password=123456; encrypt=false";

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Getdata();

        }
        private void Getdata()
        {
            try
            {
                string sql = "SELECT id,code ,name FROM courses";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" GetData  Failed :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //private void detele_Click(object sender, EventArgs e)
        //{

        //    if (dataGridView1.CurrentRow == null)
        //    {

        //        MessageBox.Show("FKKKKKK");
        //        return;

        //    }
        //    string idoo = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

        //    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this course?",
        //                                    "Confirm Delete", MessageBoxButtons.YesNo);

        //    if (dialogResult == DialogResult.No) return;


        //    try
        //    {
        //        string sql = "DELETE  FROM cousers where   id  = @id ";
        //        using (SqlConnection connection = new SqlConnection(connString))
        //        {
        //            SqlCommand command = new SqlCommand(sql, connection);
        //            command.Parameters.AddWithValue("@id", idoo);
        //            connection.Open();
        //            int rowsAffected = command.ExecuteNonQuery();
        //            if (rowsAffected > 0)
        //            {
        //                MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                Getdata();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Delete  Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        private void detele_Click(object sender, EventArgs e)
        {
            // 1. Validation: Ensure a row is actually selected
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a valid course to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Safely get the ID (check for nulls to avoid NullReferenceException)
            var cellValue = dataGridView1.CurrentRow.Cells["id"].Value;
            if (cellValue == null) return;
            string idoo = cellValue.ToString();

            // 3. User Confirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this course?",
                                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No) return;

            // 4. Database Operation
            try
            {
                // Fixed typo: "cousers" -> "courses" (Check your actual DB table name!)
                string sql = "DELETE FROM courses WHERE id = @id";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", idoo);
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Getdata(); // Refresh the grid
                        }
                        else
                        {
                            MessageBox.Show("No record was found with that ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}