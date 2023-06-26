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
    public class HoiDongChamsController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: HoiDongChams
        public ActionResult Index()
        {
            var hoiDongChams = db.HoiDongChams.Include(h => h.DeTai);
            return View(hoiDongChams.ToList());
        }

        // GET: HoiDongChams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDongCham hoiDongCham = db.HoiDongChams.Find(id);
            if (hoiDongCham == null)
            {
                return HttpNotFound();
            }
            return View(hoiDongCham);
        }

        // GET: HoiDongChams/Create
        public ActionResult Create()
        {
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai");
            return View();
        }

        // POST: HoiDongChams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maHoiDong,maDeTai,soLuongGV")] HoiDongCham hoiDongCham)
        {
            if (ModelState.IsValid)
            {
                db.HoiDongChams.Add(hoiDongCham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", hoiDongCham.maDeTai);
            return View(hoiDongCham);
        }

        // GET: HoiDongChams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDongCham hoiDongCham = db.HoiDongChams.Find(id);
            if (hoiDongCham == null)
            {
                return HttpNotFound();
            }
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", hoiDongCham.maDeTai);
            return View(hoiDongCham);
        }

        // POST: HoiDongChams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maHoiDong,maDeTai,soLuongGV")] HoiDongCham hoiDongCham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoiDongCham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDeTai = new SelectList(db.DeTais, "maDeTai", "tenDeTai", hoiDongCham.maDeTai);
            return View(hoiDongCham);
        }

        // GET: HoiDongChams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDongCham hoiDongCham = db.HoiDongChams.Find(id);
            if (hoiDongCham == null)
            {
                return HttpNotFound();
            }
            return View(hoiDongCham);
        }

        // POST: HoiDongChams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoiDongCham hoiDongCham = db.HoiDongChams.Find(id);
            db.HoiDongChams.Remove(hoiDongCham);
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
