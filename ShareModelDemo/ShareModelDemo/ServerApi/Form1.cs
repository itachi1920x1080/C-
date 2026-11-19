
namespace ServerApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnStart.Click += OnClickStart;
            btnStop.Click += OnClickStop;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            Button.CheckForIllegalCrossThreadCalls = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void OnClickStop(object? sender, EventArgs e)
        {
            this.Text = "Closing...";
            Task.Run(() => Program.StopApi()).ContinueWith(t =>
            {
                if (t.IsCompleted)
                {
                    if (Program.app == null) this.Text = "Closed";
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            });
            
        }

        private void OnClickStart(object? sender, EventArgs e)
        {
            if (Program.app != null) return;
            this.Text = $"Start Listening...";
            Task.Run(() => Program.StartApi());
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }
    }
}
