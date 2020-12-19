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
    public class ChamcongsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Chamcongs
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View(db.Chamcongs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: Chamcongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamcong chamcong = db.Chamcongs.Find(id);
            if (chamcong == null)
            {
                return HttpNotFound();
            }
            return View(chamcong);
        }

        // GET: Chamcongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chamcongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,Ngay,Doanhso,Nghi")] Chamcong chamcong)
        {
            if (ModelState.IsValid)
            {
                db.Chamcongs.Add(chamcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chamcong);
        }

        // GET: Chamcongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamcong chamcong = db.Chamcongs.Find(id);
            if (chamcong == null)
            {
                return HttpNotFound();
            }
            return View(chamcong);
        }

        // POST: Chamcongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,Ngay,Doanhso,Nghi")] Chamcong chamcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chamcong);
        }

        // GET: Chamcongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamcong chamcong = db.Chamcongs.Find(id);
            if (chamcong == null)
            {
                return HttpNotFound();
            }
            return View(chamcong);
        }

        // POST: Chamcongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamcong chamcong = db.Chamcongs.Find(id);
            db.Chamcongs.Remove(chamcong);
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
