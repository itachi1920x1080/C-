using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProfile;

public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;
    private string _photoBase64 = "";
    public string PhotoBase64 
    {
        get => _photoBase64;
        set
        {
            _photoBase64 = value;
            if (string.IsNullOrEmpty(_photoBase64))
            { _photo = null; }
            else
            {
                byte[] imageBytes = Convert.FromBase64String(PhotoBase64);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    _photo = Image.FromStream(ms);
                }
            }
        } 
    }

    // Convert Base64 to Image for DataGridView
    private Image? _photo = null;
    public Image? Photo => _photo;
   
    public static Size PhotoSize => new Size() { Width = 300, Height = 200 };

    

}
public class ImageUtitity
{
    public static string ConvertImageToBase64(Image image, Size size)
    {
        if (image == null) return "";

        // Resize image to fit within the given dimensions
        Image resizedImage = ResizeImage(image, size);

        using (MemoryStream ms = new MemoryStream())
        {
            resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Use JPEG for smaller size
            return Convert.ToBase64String(ms.ToArray());
        }
    }
    public static Image ResizeImage(Image image, Size size)
    {
        int newWidth = image.Width;
        int newHeight = image.Height;

        // Maintain aspect ratio
        if (newWidth > size.Width || newHeight > size.Height)
        {
            double ratioX = (double)size.Width / newWidth;
            double ratioY = (double)size.Height / newHeight;
            double ratio = Math.Min(ratioX, ratioY);

            newWidth = (int)(newWidth * ratio);
            newHeight = (int)(newHeight * ratio);
        }

        Bitmap resizedImage = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }

        return resizedImage;
    }
}