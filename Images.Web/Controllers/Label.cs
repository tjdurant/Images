using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CellTool.Storage;
using CellTool.Storage.Models;

namespace Images.Web.Controllers
{
    public class Label : Controller
    {
        private CellToolContext db = new CellToolContext();

        // GET: Label
        public ActionResult Index()
        {
            return View(db.CellData.ToList());
        }

        // GET: Label/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CellData cellData = db.CellData.Find(id);
            if (cellData == null)
            {
                return HttpNotFound();
            }
            return View(cellData);
        }

        // GET: Label/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Label/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImageBin,Annotator,CellType,Label,X,Y,W,H")] CellData cellData)
        {
            if (ModelState.IsValid)
            {
                db.CellData.Add(cellData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cellData);
        }

        // GET: Label/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CellData cellData = db.CellData.Find(id);
            if (cellData == null)
            {
                return HttpNotFound();
            }
            return View(cellData);
        }

        // POST: Label/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageBin,Annotator,CellType,Label,X,Y,W,H")] CellData cellData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cellData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cellData);
        }

        // GET: Label/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CellData cellData = db.CellData.Find(id);
            if (cellData == null)
            {
                return HttpNotFound();
            }
            return View(cellData);
        }

        // POST: Label/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CellData cellData = db.CellData.Find(id);
            db.CellData.Remove(cellData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
