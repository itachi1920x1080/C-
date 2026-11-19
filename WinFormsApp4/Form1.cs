using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Button to add photo
            Button btnAddPhoto = new Button
            {
                Text = "Add Photo",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnAddPhoto.Click += BtnAddPhoto_Click;

            // PictureBox to display the photo
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Add controls to the form
            this.Controls.Add(pictureBox);
            this.Controls.Add(btnAddPhoto);
        }

        private void BtnAddPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select a Photo"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Load selected image
                Image img = Image.FromFile(ofd.FileName);
                pictureBox.Image = img;

                // Optional: Save it as .bin
                string binPath = Path.Combine(
                    Path.GetDirectoryName(ofd.FileName)!,
                    Path.GetFileNameWithoutExtension(ofd.FileName) + ".bin"
                );
                SaveImageToBin(img, binPath);
                MessageBox.Show($"Photo saved as {binPath}");
            }
        }

        private void SaveImageToBin(Image img, string path)
        {
            using MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            File.WriteAllBytes(path, ms.ToArray());
        }
    }
}