namespace RecWinForm;

public partial class Form1 : Form
{
    private DataGridViewRow? curRow = null;
    public Form1()
    {
        InitializeComponent();
        ConfigGridView();

        grpCurRec.Enabled = (dgvRecs.CurrentRow != null);

        //Subscribing the event Click of the button "Refresh" to handle by an anonymous method
        btnRefresh.Click += (object? sender, EventArgs e) =>
        {
            dgvRecs.Rows.Clear();
            curRow = null;
            Program.Recs.ForEach(rect =>
            {
                dgvRecs.Rows.Add(rect.No, rect.Width, rect.Length, rect.Area);
            });
        };

        //Subscribing the event Click of the button "Remove From Grid" to handle by an anonymous method
        btnGridRemove.Click += (object? sender, EventArgs e) =>
        {
            if (dgvRecs.CurrentRow == null) return;
            dgvRecs.Rows.Remove(dgvRecs.CurrentRow);
        };

        //Subscribing the event Click of the button "Remove From Data" to handle by an anonymous method
        btnDataRemove.Click += (object? sender, EventArgs e) =>
        {
            if (dgvRecs.CurrentRow == null) return;
            int? no = (int?)dgvRecs.CurrentRow.Cells["colNo"].Value;
            Rectangle? removed = Program.Recs.FirstOrDefault(rect => rect.No == no);
            if (removed != null && Program.Recs.Remove(removed))
            {
                Task.Run(() =>
                {
                    MessageBox.Show($"A rectangle no, {removed.No}, was successfully removed", "Removing",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
                ViewCurrentRectangle();
            }
        };

        //Subscribing the event Click of the button "Remove Both" to handle by an anonymous method
        btnRemoveBoth.Click += (object? sender, EventArgs e) =>
        {
            if (dgvRecs.CurrentRow == null) return;
            Rectangle removed = Program.Recs[dgvRecs.CurrentRow.Index];
            if (Program.Recs.Remove(removed))
            {
                dgvRecs.Rows.Remove(dgvRecs.CurrentRow);
            }
        };

        //Subscribing the event SelectionChanged of the DataGridView Refresh to handle by an anonymous method
        dgvRecs.SelectionChanged += (object? sender, EventArgs e) =>
        {
            grpCurRec.Enabled = (dgvRecs.CurrentRow != null);
            if (dgvRecs.CurrentRow != curRow) ViewCurrentRectangle();
        };

        txtWidth.Leave += OnInputBoxLeave;
        txtLength.Leave += OnInputBoxLeave;
    }

    private void OnInputBoxLeave(object? sender, EventArgs e)
    {
        if (dgvRecs.CurrentRow is null) return; 
        if (!(sender == txtWidth || sender == txtLength)) return;
        TextBox? txt = sender as TextBox;
        if (txt == null) return;
        if (double.TryParse(txt.Text, out double newValue) == false) return;

        int no = (int)dgvRecs.CurrentRow.Cells["colNo"].Value;
        var foundRec = Program.Recs.FirstOrDefault(r => r.No == no);
        if (foundRec != null)
        {
            if (txt == txtWidth)
            {
                foundRec.Width = newValue;
                dgvRecs.CurrentRow.Cells["colWidth"].Value = newValue;
            }
            if (txt == txtLength)
            {
                foundRec.Length = newValue;
                dgvRecs.CurrentRow.Cells["colLength"].Value = newValue;
            }
            dgvRecs.CurrentRow.Cells["colArea"].Value = foundRec.Area;
            txtArea.Text = foundRec.Area.ToString("N2");
        }
    }

    private void ViewCurrentRectangle()
    {
        curRow = dgvRecs.CurrentRow;
        int? no = (int?)curRow?.Cells["colNo"].Value;
        Rectangle? curRec = Program.Recs.FirstOrDefault(rect => rect.No == no);
        txtNo.Text = curRec?.No.ToString();
        txtWidth.Text = curRec?.Width.ToString("N2");
        txtLength.Text = curRec?.Length.ToString("N2");
        txtArea.Text = curRec?.Area.ToString("N2");
    }

    private void ConfigGridView()
    {
        dgvRecs.Columns.Clear();
        dgvRecs.Columns.Add("colNo", "No");
        dgvRecs.Columns.Add("colWidth", "Width");
        dgvRecs.Columns.Add("colLength", "Length");
        dgvRecs.Columns.Add("colArea", "Area");

        foreach (DataGridViewColumn col in dgvRecs.Columns)
        {
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (col.Name == "colNo") continue;
            col.DefaultCellStyle.Format = "N2";
        }
        dgvRecs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }
}
