using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanliNS.Models;

namespace QuanliNS.Controllers
{
    public class TamungsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Tamungs
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View(db.Tamungs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        // GET: Tamungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamung tamung = db.Tamungs.Find(id);
            if (tamung == null)
            {
                return HttpNotFound();
            }
            return View(tamung);
        }

        // GET: Tamungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,NgayTU,Sotien")] Tamung tamung)
        {
            if (ModelState.IsValid)
            {
                db.Tamungs.Add(tamung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamung);
        }

        // GET: Tamungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamung tamung = db.Tamungs.Find(id);
            if (tamung == null)
            {
                return HttpNotFound();
            }
            return View(tamung);
        }

        // POST: Tamungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,NgayTU,Sotien")] Tamung tamung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamung);
        }

        // GET: Tamungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamung tamung = db.Tamungs.Find(id);
            if (tamung == null)
            {
                return HttpNotFound();
            }
            return View(tamung);
        }

        // POST: Tamungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamung tamung = db.Tamungs.Find(id);
            db.Tamungs.Remove(tamung);
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
