using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.Page.Controllers
{
    public class OrderController : Controller
    {
        // GET: Page/Order
        myHondacontext db = new myHondacontext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Status(int id, int status)
        {
            try
            {
                dathang dh = db.dathangs.Find(id);
                if (dh.status != 4)
                {
                    dh.status = status;
                    db.Entry(dh).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    khachhang kh = db.khachhangs.Find(dh.makh);
                    kh.sotiendamua = kh.sotiendamua + dh.tongtien;
                    db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Json(new { success = true, ms = "đã chuyển trạng thái" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "lỗi rồi" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}