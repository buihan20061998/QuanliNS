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
    public class PhongbansController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Phongbans
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View(db.Phongbans.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        // GET: Phongbans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // GET: Phongbans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phongbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB,DiaDiem,SoDT")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                db.Phongbans.Add(phongban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongban);
        }

        // GET: Phongbans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: Phongbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB,DiaDiem,SoDT")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongban);
        }

        // GET: Phongbans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongban phongban = db.Phongbans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: Phongbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phongban phongban = db.Phongbans.Find(id);
            db.Phongbans.Remove(phongban);
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
