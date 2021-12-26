using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
using System.Data.Entity;
namespace myHondaMVC.Areas.AdminCP.Controllers
{
    public class DonhangController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: AdminCP/Donhang
        public ActionResult Index()
        {
            var d = from dh in db.dathangs select dh;
            return View(d);
        }
        public ActionResult Details(int id)
        {
            var rs = db.dathangs.Find(id);
            ViewBag.ctdh = db.chitietdathangs.Where(x => x.madh == id).ToList();
            return View(rs);
        }
        public ActionResult Status(int id,int status)
        {
            dathang dh = db.dathangs.Find(id);
            if (dh.status != 4)
            {
                dh.status = status;
                db.Entry(dh).State= EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { success = true, ms = "đã chuyển trạng thái đơn hàng." }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            dathang dh = db.dathangs.Find(id);
            var ct = db.chitietdathangs.Where(x => x.madh == id);
            db.chitietdathangs.RemoveRange(ct);
            db.dathangs.Remove(dh);
            db.SaveChanges();
            return Json(new { success = true, ms = "đã xóa đơn hàng " + dh.madh }, JsonRequestBehavior.AllowGet);
        }

    }
}