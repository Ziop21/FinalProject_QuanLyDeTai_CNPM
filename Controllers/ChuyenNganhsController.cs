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
    public class ChuyenNganhsController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: ChuyenNganhs
        public ActionResult Index()
        {
            var chuyenNganhs = db.ChuyenNganhs.Include(c => c.GiangVien);
            return View(chuyenNganhs.ToList());
        }

        // GET: ChuyenNganhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Create
        public ActionResult Create()
        {
            ViewBag.truongBoMon = new SelectList(db.GiangViens, "account_ID", "tenGiangVien");
            return View();
        }

        // POST: ChuyenNganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maChuyenNganh,tenChuyenNganh,truongBoMon")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.ChuyenNganhs.Add(chuyenNganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.truongBoMon = new SelectList(db.GiangViens, "account_ID", "tenGiangVien", chuyenNganh.truongBoMon);
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.truongBoMon = new SelectList(db.GiangViens, "account_ID", "tenGiangVien", chuyenNganh.truongBoMon);
            return View(chuyenNganh);
        }

        // POST: ChuyenNganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maChuyenNganh,tenChuyenNganh,truongBoMon")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenNganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.truongBoMon = new SelectList(db.GiangViens, "account_ID", "tenGiangVien", chuyenNganh.truongBoMon);
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // POST: ChuyenNganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            db.ChuyenNganhs.Remove(chuyenNganh);
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
