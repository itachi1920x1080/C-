
using RestClientLib;
using System.Collections.Generic;

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.DataSource = new List<Shares.Product>();
            dgvPrds.DataSource = bs;
            btnFetch.Click += OnClickFetch;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
        }

        private void OnClickFetch(object? sender, EventArgs e)
        {
            RestClient restClient = new RestClient(Shares.Setting.BaseUrl);
            Task.Run(async () =>
            {
                try
                {
                    var result = await restClient.GetAsync<List<Shares.Product>>(Shares.Setting.GetAllProductsEndpoint);
                    bs.DataSource = result;
                    bs.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
