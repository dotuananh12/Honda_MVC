using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.AdminCP.Controllers
{
    public class NhacungcapController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: AdminCP/Nhacungcap
        public ActionResult Index()
        {
            var ncc = from sp in db.nhacungcaps select sp;
            return View(ncc);
        }
        public ActionResult Create(string tenncc, string sdt, string diachi, string ghichu)
        {
            try
            {
                nhacungcap ncc = new nhacungcap();
                //ncc.mancc = mancc;
                ncc.tenncc = tenncc;
                ncc.sdt = sdt;
                ncc.diachi = diachi;
                ncc.ghichu = ghichu;

                db.nhacungcaps.Add(ncc);
                db.SaveChanges();

                return Json(new { success = true, ms = "thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi khi luu du lieu" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Get(int id)
        {
            try
            {
                var rs = db.nhacungcaps.Where(x => x.mancc == id).Select(x => new { mancc = x.mancc, tenncc = x.tenncc, sdt = x.sdt, diachi = x.diachi, ghichu = x.ghichu }).SingleOrDefault();

                return Json(new { success = true, dt = rs }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi khi dua du lieu len model" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int mancc, string tenncc, string sdt, string diachi, string ghichu)
        {
            try
            {
                nhacungcap ncc = db.nhacungcaps.Find(mancc);
                ncc.tenncc = tenncc;
                ncc.sdt = sdt;
                ncc.diachi = diachi;
                ncc.ghichu = ghichu;

                db.Entry(ncc).State = System.Data.Entity.EntityState.Modified;
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
                nhacungcap ncc = db.nhacungcaps.Find(id);
                db.nhacungcaps.Remove(ncc);
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