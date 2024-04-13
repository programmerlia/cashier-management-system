using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    internal class Shit
    {

        public static byte[] ImageToBlob(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }


        private Color DarkenColor(Color color, float factor)
        {
            int r = (int)(color.R * (1 - factor));
            int g = (int)(color.G * (1 - factor));
            int b = (int)(color.B * (1 - factor));
            return Color.FromArgb(r, g, b);
        }
    }
}
