using CellTool.Storage;
using CellTool.Storage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CellTool.Driver
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CellToolContext())
            {
                ImageHandler ih = new ImageHandler();

                Console.Write("Enter path for new Cell Group: ");
                var imagePath = Console.ReadLine();

                string[] fileEntries = Directory.GetFiles(imagePath);
                

                foreach (string line in fileEntries)
                {
                    //console.writeline(line);
                    Image img = Image.FromFile(line);


                    // .net obj for record in db
                    var cur = new CreateCellGroup();
                    var ImgBin = cur.ImageBin;

                    // adding data to object
                    ImgBin = ih.imageToByteArray(img)

                    // mapping to ef model and adding to virtual table 
                    db.OriginalCellData.Add(ImgBin);
                    db.SaveChanges();
                }
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Cell Group Name: ");
                var name = Console.ReadLine();

                // Display all Blogs from the database 
                var query = from b in db.OriginalCellData
                            orderby b.GroupName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.GroupName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            /*
            In this article I will explain with an example, how to perform select, insert, edit, update, 
            delete using Entity Framework in ASP.Net using C# and VB.Net.
            This process is also known as CRUD i.e. Create, Read, Update and Delete in 
            GridView using Entity Framework in ASP.Net.
            //*/
            //SqlCommand cmd;
            //SqlConnection con;
            //SqlDataAdapter da;

            //con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = CellData; Integrated Security = True; MultipleActiveResultSets = True");
            


            //ImageHandler ih = new ImageHandler();
            

            //// Entity framework here
            //Database.SetInitializer(new CellToolInitializer());



            //string sourceDir = "C:/Users/thoma/Documents/00GitHub/00_LOCAL_ONLY/Symmetric_Rbc_Crop/";
            //// add file name; if in, don't add
            //string[] fileEntries = Directory.GetFiles(sourceDir);

            //console.writeline(sourcedir);
            //foreach (string line in fileentries)
            //{
            //    //console.writeline(line);
            //    byte[] arr;
            //    image img = image.fromfile(line);
            //    arr = imagetobytearray(img);

            //    sqlbulkimport(arr);

           

            //}


        }
    }
}