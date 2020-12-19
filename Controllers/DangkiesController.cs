using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using QuanliNS.Models;

namespace QuanliNS.Controllers
{
    public class DangkiesController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Dangkies
        public ActionResult Index()
        {
            var dangkys = db.Dangkys.Include(d => d.Role);
            return View(dangkys.ToList());
        }

        // GET: Dangkies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangky dangky = db.Dangkys.Find(id);
            if (dangky == null)
            {
                return HttpNotFound();
            }
            return View(dangky);
        }

        // GET: Dangkies/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Dangkies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,UserName,Password,RoleID")] Dangky dangky)
        {
            if (ModelState.IsValid)
            {
                dangky.Password = GetMD5(dangky.Password);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Dangkys.Add(dangky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", dangky.RoleID);
            return View(dangky);
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        // GET: Dangkies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangky dangky = db.Dangkys.Find(id);
            if (dangky == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", dangky.RoleID);
            return View(dangky);
        }

        // POST: Dangkies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,UserName,Password,RoleID")] Dangky dangky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", dangky.RoleID);
            return View(dangky);
        }

        // GET: Dangkies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangky dangky = db.Dangkys.Find(id);
            if (dangky == null)
            {
                return HttpNotFound();
            }
            return View(dangky);
        }

        // POST: Dangkies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dangky dangky = db.Dangkys.Find(id);
            db.Dangkys.Remove(dangky);
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
