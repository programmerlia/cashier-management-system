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
    }
}
