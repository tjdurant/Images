using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CellTool.Storage.Content
{
    public class ImageHandler
    {
        /*
        Server.MapPath(".") returns the current physical directory of the file (e.g. aspx) being executed
        Server.MapPath("..") returns the parent directory
        Server.MapPath("~") returns the physical path to the root of the application
        Server.MapPath("/") returns the physical path to the root of the domain name (is not necessarily the same as the root of the application)
        */
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public void SqlBulkImport(object ImgArray)
        {
            con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = CellData; Integrated Security = True; MultipleActiveResultSets = True");
            con.Open();

            cmd = new SqlCommand("INSERT INTO CellDatas (ImageBin) VALUES (@ImageBin)", con);
            
            cmd.Parameters.AddWithValue("@ImageBin", ImgArray);

            cmd.ExecuteNonQuery();

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        string sourceDir = "C:/Users/thoma/Documents/00GitHub/00_LOCAL_ONLY/Symmetric_Rbc_Crop/";

        string[] fileEntries = Directory.GetFiles(sourceDir);

        byte[] bytes = System.IO.File.ReadAllBytes(filename);

    }
}
