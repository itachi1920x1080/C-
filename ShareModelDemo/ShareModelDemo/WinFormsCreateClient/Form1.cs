
namespace WinFormsCreateClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnClear.Click += (_, _) =>
            {
                txtNo.Clear();
                txtName.Clear();
                txtPrice.Clear();
            };
            btnSubmit.Click += OnClickSubmit;
        }

        private void OnClickSubmit(object? sender, EventArgs e)
        {
            if (int.TryParse(txtNo.Text, out int no) == false)
            {
                MessageBox.Show("Invalid no");
                return;
            }
            if (double.TryParse(txtPrice.Text, out double price) == false)
            {
                MessageBox.Show("Invalid price");
                return;
            }
            var newProduct = new Shares.Product()
            {
                No = no,
                Name = txtName.Text,
                Price = price
            };
            var restClient= new RestClientLib.RestClient(Shares.Setting.BaseUrl);
            Task.Run(async () =>
            {
                try
                {
                    var result = await restClient.PostAsync<Shares.Product, int>(Shares.Setting.PostProductEndpoint, newProduct);
                    if (result == -1)
                    {
                        MessageBox.Show($"Product with no, {newProduct.No}, does already exist");
                    }
                    else
                    {
                        MessageBox.Show("Successfully");
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
