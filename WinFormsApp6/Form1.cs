using Microsoft.Data.SqlClient;
namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connString = "data source=10.4.13.30,14333\\teachingserver; initial catalog=enrolldb_m6; user id=sreng; password=123456; encrypt=false";
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
    }
}
