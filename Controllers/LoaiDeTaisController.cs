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
    public class LoaiDeTaisController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: LoaiDeTais
        public ActionResult Index()
        {
            var loaiDeTais = db.LoaiDeTais.Include(l => l.ChuyenNganh);
            return View(loaiDeTais.ToList());
        }

        // GET: LoaiDeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDeTai loaiDeTai = db.LoaiDeTais.Find(id);
            if (loaiDeTai == null)
            {
                return HttpNotFound();
            }
            return View(loaiDeTai);
        }

        // GET: LoaiDeTais/Create
        public ActionResult Create()
        {
            ViewBag.maChuyenNganh = new SelectList(db.ChuyenNganhs, "maChuyenNganh", "tenChuyenNganh");
            return View();
        }

        // POST: LoaiDeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLoaiDeTai,tenLoaiDeTai,nienKhoa,hocKy,maChuyenNganh")] LoaiDeTai loaiDeTai)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDeTais.Add(loaiDeTai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maChuyenNganh = new SelectList(db.ChuyenNganhs, "maChuyenNganh", "tenChuyenNganh", loaiDeTai.maChuyenNganh);
            return View(loaiDeTai);
        }

        // GET: LoaiDeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDeTai loaiDeTai = db.LoaiDeTais.Find(id);
            if (loaiDeTai == null)
            {
                return HttpNotFound();
            }
            ViewBag.maChuyenNganh = new SelectList(db.ChuyenNganhs, "maChuyenNganh", "tenChuyenNganh", loaiDeTai.maChuyenNganh);
            return View(loaiDeTai);
        }

        // POST: LoaiDeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLoaiDeTai,tenLoaiDeTai,nienKhoa,hocKy,maChuyenNganh")] LoaiDeTai loaiDeTai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDeTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maChuyenNganh = new SelectList(db.ChuyenNganhs, "maChuyenNganh", "tenChuyenNganh", loaiDeTai.maChuyenNganh);
            return View(loaiDeTai);
        }

        // GET: LoaiDeTais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDeTai loaiDeTai = db.LoaiDeTais.Find(id);
            if (loaiDeTai == null)
            {
                return HttpNotFound();
            }
            return View(loaiDeTai);
        }

        // POST: LoaiDeTais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiDeTai loaiDeTai = db.LoaiDeTais.Find(id);
            db.LoaiDeTais.Remove(loaiDeTai);
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
