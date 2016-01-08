using CellTool.Driver;
using CellTool.Storage;
using CellTool.Storage.Models;
using Images.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Images.Web.Controllers
{
    public class LabelController : Controller
    {
        // instantiate Db connection class; CellToolContext which relies on the connection
        // string in the Web.Config file. 
        

        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        ImageHandler ih = new ImageHandler();

        private readonly CellToolContext _db;

        public LabelController()
        {
            _db = new CellToolContext();

        }

        public ActionResult Index()
        {
            var query =
                        (from c in _db.OriginalCellData
                        select new { c.ImageBin }).First();

            var imArray = query.ImageBin;

            //var imArray = _db.OriginalCellData.First<CellGroup>(a => a.ImageBin);
            string imageBase64Data = Convert.ToBase64String(imArray);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            ViewBag.ImageData = imageDataURL;
            return View();
        }

        public ActionResult GetImage()
        {
            string path = Server.MapPath("~/images/computer.png");
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/png");
        }

        //public ActionResult Index()
        //{

        //    /*"There's no better thing than Inversion of Control and Dependency Injection, 
        //    generic specialization, the decorator pattern, chains of responsibilities, 
        //    and extensible software."     */


        //    //GetCellImage cellData = new GetCellImage();


        //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CellData;Integrated Security=True;MultipleActiveResultSets=True";

        //    // establish database connection
        //    SqlConnection objConn = new SqlConnection(connectionString);
        //    objConn.Open();

        //    // establish link (adapter) between database and dataset object
        //    SqlDataAdapter daCellData = new SqlDataAdapter("Select * From Authors", objConn);

        //    /* You must declare and create an instance of a DataSet object, at which time 
        //    you can supply a name for the entire DataSet before you can start to load any 
        //    data.The name may contain several distinct tables. */
        //    //DataSet dsCellDatas = new DataSet("CellDatas");

        //    /* The SqlDataAdapter class provides two methods, Fill and FillSchema, that are 
        //    crucial to loading this data. Both of these methods load information into a DataSet. 
        //    Fill loads the data itself, and FillSchema loads all of the available metadata about 
        //    a particular table (such as column names, primary keys, and constraints). A good way 
        //    to handle the data loading is to run FillSchema followed by Fill. For example: */
        //    //daCellData.FillSchema(dsCellDatas, SchemaType.Source, "CellDatas");
        //    //daCellData.Fill(dsCellDatas, "CellDatas");

        //    /* The data is now available as an individual DataTable object within the Tables 
        //    collection of the DataSet. If you specified a table name in the calls to FillSchema
        //    and Fill, you can use that name to access the specific table that you want.*/
        //    //DataTable tblCelldatas;
        //    //tblCelldatas = dsCellDatas.Tables["CellDatas"];

        //    //foreach (DataRow drCurrent in tblAuthors.Rows)
        //    //{
        //    //    Console.WriteLine("{0} {1}",
        //    //        drCurrent["au_fname"].ToString(),
        //    //        drCurrent["au_lname"].ToString());
        //    //}
        //    //Console.ReadLine();

        //    return View();
        //}
        ////public PartialViewResult DislpayImage(int id)
        ////{
        ////    DataSet dsa = new DataSet();

        ////    dsa = objImage.getUserImage(id);
        ////    var imagedata = dsa.Tables[0].Columns["ImageBin"];
        ////    var f = File(imagedata, "image/png");

        ////    return PartialView(f);
        ////}
    }
}   