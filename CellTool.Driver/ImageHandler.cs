using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CellTool.Driver
{
    public class ImageHandler
    {
        /*
        Server.MapPath(".") returns the current physical directory of the file (e.g. aspx) being executed
        Server.MapPath("..") returns the parent directory
        Server.MapPath("~") returns the physical path to the root of the application
        Server.MapPath("/") returns the physical path to the root of the domain name (is not necessarily the same as the root of the application)
        */

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
