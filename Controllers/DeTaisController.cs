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
    public class DeTaisController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: DeTais
        public ActionResult Index()
        {
            var deTais = db.DeTais.Include(d => d.LoaiDeTai1);
            return View(deTais.ToList());
        }

        // GET: DeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // GET: DeTais/Create
        public ActionResult Create()
        {
            ViewBag.loaiDeTai = new SelectList(db.LoaiDeTais, "maLoaiDeTai", "tenLoaiDeTai");
            return View();
        }

        // POST: DeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maDeTai,tenDeTai,mucTieu,yeuCau,sanPham,chuThich,soLuongSinhVienToiDa,duocDangKyKhacChuyenNganh,nienKhoa,loaiDeTai,diem,truongNhom,gvHuongDan")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.DeTais.Add(deTai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.loaiDeTai = new SelectList(db.LoaiDeTais, "maLoaiDeTai", "tenLoaiDeTai", deTai.loaiDeTai);
            return View(deTai);
        }

        // GET: DeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            ViewBag.loaiDeTai = new SelectList(db.LoaiDeTais, "maLoaiDeTai", "tenLoaiDeTai", deTai.loaiDeTai);
            return View(deTai);
        }

        // POST: DeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maDeTai,tenDeTai,mucTieu,yeuCau,sanPham,chuThich,soLuongSinhVienToiDa,duocDangKyKhacChuyenNganh,nienKhoa,loaiDeTai,diem,truongNhom,gvHuongDan")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loaiDeTai = new SelectList(db.LoaiDeTais, "maLoaiDeTai", "tenLoaiDeTai", deTai.loaiDeTai);
            return View(deTai);
        }

        // GET: DeTais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // POST: DeTais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeTai deTai = db.DeTais.Find(id);
            db.DeTais.Remove(deTai);
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
