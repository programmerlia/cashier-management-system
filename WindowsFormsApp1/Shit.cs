using Bunifu.UI.WinForms;
using MySqlX.XDevAPI.Relational;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace Cashetor
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


public static Color LightenHexColor(Color color, float factor)
    {
            string hexColor = ColorTranslator.ToHtml(color);
            hexColor = hexColor.TrimStart('#');

        int r = int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        int g = int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        int b = int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        r = (int)Math.Min(255, r + 255 * factor);
        g = (int)Math.Min(255, g + 255 * factor);
        b = (int)Math.Min(255, b + 255 * factor);

        return Color.FromArgb(r, g, b);
    }



        public static void setupTableClr(BunifuDataGridView tbl)
        {
            tbl.ColumnHeadersDefaultCellStyle.SelectionBackColor = Shit.LightenHexColor(Variables.clrheader, 0.1f);
            tbl.ColumnHeadersDefaultCellStyle.BackColor = Variables.clrheader;
            tbl.RowsDefaultCellStyle.BackColor = Color.White;
            tbl.RowsDefaultCellStyle.SelectionBackColor = Shit.LightenHexColor(Variables.clrsecondarybtn, 0.9f);
            ;
        }
}
}
