using CellTool.Driver;
using CellTool.Storage;
using CellTool.Storage.Models;
using Images.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            ImageHandler ih = new ImageHandler();
            MemoryStream ms = new MemoryStream();

            var query = (from c in _db.OriginalCellData select new { c.ImagePath }).First();

            var imageRelativePath = query.ImagePath;
            var imageOpen = Image.FromFile(imageRelativePath);

            imageOpen.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            var imArray = ms.ToArray();


            string imageBase64Data = Convert.ToBase64String(imArray);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            ViewBag.ImageData = imageDataURL;

            return View();
        }
    }
}   