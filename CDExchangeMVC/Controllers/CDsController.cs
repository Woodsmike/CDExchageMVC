using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CDExchangeMVC.Models;

namespace CDExchangeMVC.Controllers
{
    public class CDsController : Controller
    {
        private CDExchangeMVCContext db = new CDExchangeMVCContext();

        // GET: CDs
        public ActionResult Index()
        {
            var cDs = db.CDs.Include(c => c.Category).Include(c => c.Customer);
            return View(cDs.ToList());
        }

        // GET: CDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CD cD = db.CDs.Find(id);
            if (cD == null)
            {
                return HttpNotFound();
            }
            return View(cD);
        }

        // GET: CDs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "FirstName");
            return View();
        }

        // POST: CDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Artist,ReleaseDate,Description,SerialNumber,CategoryID,CustomerID")] CD cD)
        {
            if (ModelState.IsValid)
            {
                db.CDs.Add(cD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", cD.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "FirstName", cD.CustomerID);
            return View(cD);
        }

        // GET: CDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CD cD = db.CDs.Find(id);
            if (cD == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", cD.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "FirstName", cD.CustomerID);
            return View(cD);
        }

        // POST: CDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Artist,ReleaseDate,Description,SerialNumber,CategoryID,CustomerID")] CD cD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", cD.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "FirstName", cD.CustomerID);
            return View(cD);
        }

        // GET: CDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CD cD = db.CDs.Find(id);
            if (cD == null)
            {
                return HttpNotFound();
            }
            return View(cD);
        }

        // POST: CDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CD cD = db.CDs.Find(id);
            db.CDs.Remove(cD);
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
