using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDeTai.Models;

namespace QuanLyDeTai.Controllers
{
    public class NhomsController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: Nhoms
        public ActionResult Index()
        {
            var nhoms = db.Nhoms.Include(n => n.DeTai);
            return View(nhoms.ToList());
        }

        // GET: Nhoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhom nhom = db.Nhoms.Find(id);
            if (nhom == null)
            {
                return HttpNotFound();
            }
            return View(nhom);
        }

        // GET: Nhoms/Create
        public ActionResult Create()
        {
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai");
            return View();
        }

        // POST: Nhoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNhom,maNhomTruong,soLuongSv,maDeTai")] Nhom nhom)
        {
            if (ModelState.IsValid)
            {
                db.Nhoms.Add(nhom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", nhom.maDeTai);
            return View(nhom);
        }

        // GET: Nhoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhom nhom = db.Nhoms.Find(id);
            if (nhom == null)
            {
                return HttpNotFound();
            }
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", nhom.maDeTai);
            return View(nhom);
        }

        // POST: Nhoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNhom,maNhomTruong,soLuongSv,maDeTai")] Nhom nhom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", nhom.maDeTai);
            return View(nhom);
        }

        // GET: Nhoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhom nhom = db.Nhoms.Find(id);
            if (nhom == null)
            {
                return HttpNotFound();
            }
            return View(nhom);
        }

        // POST: Nhoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhom nhom = db.Nhoms.Find(id);
            db.Nhoms.Remove(nhom);
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
