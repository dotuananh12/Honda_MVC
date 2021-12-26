using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;

namespace myHondaMVC.Areas.AdminCP.Controllers
{
    public class loaixemayController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: AdminCP/loaixemay
        public ActionResult Index()
        {
            return View(db.loaixes.ToList());
        }
        [HttpPost]
        public ActionResult create(loaixe lx)
        {
            db.loaixes.Add(lx);
            db.SaveChanges();
            return Json(new { success = true, ms = "thêm thành công" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public ActionResult Get(int id)
        {
            try
            {
                var rs = db.loaixes.Where(x => x.maloai == id).Select(x => new {
                    x.maloai,
                    x.tenloai,
                     x.ghichu
                }).SingleOrDefault();

                return Json(new { success = true, dt = rs }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi khi dua du lieu len model" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int maloai, string tenloai, string ghichu)
        {
            try
            {
                loaixe lx = db.loaixes.Find(maloai);
                lx.tenloai = tenloai;
               
                lx.ghichu = ghichu;

                db.Entry(lx).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, ms = "sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi luu du lieu" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                loaixe lx = db.loaixes.Where(x => x.maloai == id).SingleOrDefault();
                db.loaixes.Remove(lx);
                db.SaveChanges();

                return Json(new { success = true, ms = "xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi luu du lieu" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}