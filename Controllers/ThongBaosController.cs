using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using QuanLyDeTai.Models;

namespace QuanLyDeTai.Controllers
{
    public class ThongBaosController : Controller
    {
        private QuanLyDeTaiEntities1 db = new QuanLyDeTaiEntities1();

        // GET: ThongBaos
        public ActionResult Index()
        {
            var thongBaos = db.ThongBaos.ToList();
            return View(thongBaos);
        }

        // GET: ThongBaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // GET: ThongBaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongBaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("themThongBao")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formthongBao, HttpPostedFileBase file)
        {
            var thongBao = new ThongBao();
            if (file != null)
            {
                string FileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Upload"), FileName);
                file.SaveAs(path);
                thongBao.fileDinhKem = FileName;
            }
            var tieuDe = formthongBao["tieuDe"];
            var moTa = formthongBao["moTa"];
            var noiDung = formthongBao["noiDung"];
            var trangThai = Convert.ToByte(formthongBao["trangThai"]);
            thongBao.tieuDe = tieuDe;
            thongBao.moTa = moTa;
            thongBao.noiDung = noiDung;
            thongBao.trangThai = trangThai;
            thongBao.ngayTao = DateTime.Now;
            db.ThongBaos.Add(thongBao);
            db.SaveChanges();
            return RedirectToAction("Index", "ThongBaos");
        }
        public ActionResult XoaThongBao(int id)
        {
            ThongBao thongBao = db.ThongBaos.Find(id);
            db.ThongBaos.Remove(thongBao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: ThongBaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // POST: ThongBaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maThongBao,tieuDe,moTa,noiDung,trangThai,ngayTao")] ThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongBao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongBao);
        }

        // GET: ThongBaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBaos.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // POST: ThongBaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongBao thongBao = db.ThongBaos.Find(id);
            db.ThongBaos.Remove(thongBao);
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
