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
    public class NhanviensController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Nhanviens
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                var nhanviens = db.Nhanviens.Include(n => n.Chucvu).Include(n => n.Phongban);
                return View(nhanviens.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        // GET: Nhanviens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: Nhanviens/Create
        public ActionResult Create()
        {
            ViewBag.MaCV = new SelectList(db.Chucvus, "MaCV", "TenCV");
            ViewBag.MaPB = new SelectList(db.Phongbans, "MaPB", "TenPB");
            return View();
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTen,NamSinh,Diachi,Gioitinh,SoCMND,SoDT,Email,MaPB,MaCV,Quyen")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Nhanviens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCV = new SelectList(db.Chucvus, "MaCV", "TenCV", nhanvien.MaCV);
            ViewBag.MaPB = new SelectList(db.Phongbans, "MaPB", "TenPB", nhanvien.MaPB);
            return View(nhanvien);
        }

        // GET: Nhanviens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.Chucvus, "MaCV", "TenCV", nhanvien.MaCV);
            ViewBag.MaPB = new SelectList(db.Phongbans, "MaPB", "TenPB", nhanvien.MaPB);
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTen,NamSinh,Diachi,Gioitinh,SoCMND,SoDT,Email,MaPB,MaCV,Quyen")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCV = new SelectList(db.Chucvus, "MaCV", "TenCV", nhanvien.MaCV);
            ViewBag.MaPB = new SelectList(db.Phongbans, "MaPB", "TenPB", nhanvien.MaPB);
            return View(nhanvien);
        }

        // GET: Nhanviens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            db.Nhanviens.Remove(nhanvien);
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
