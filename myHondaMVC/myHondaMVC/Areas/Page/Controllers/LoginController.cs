using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.Page.Controllers
{
    public class LoginController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: Page/Login
        public ActionResult Index()
        {
            return View();
        }
      
        public JsonResult Login(string email, string password)
        {
            if (db.khachhangs.Where(x => x.email == email && x.pass == password).Count() >= 1)
            {
                var nd = db.khachhangs.Where(x => x.email == email && x.pass == password).SingleOrDefault();
                Session["nguoidung_khach"] = nd;

                return Json(new { success = true, msg = "đăng nhập thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, emai = email, pass = password, msg = "đăng nhập không đúng" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult kiemtralogin()
        {
            if (Session["nguoidung_khach"] != null)
            {
                khachhang nd = (khachhang)Session["nguoidung_khach"];
                return Json(new { success = true, user = nd.tenkh }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Signup(khachhang kh)
        {
          
  
            
                kh.sotiendamua = 0;
                kh.status = true;
                kh.img = "donghia.jpg";
                db.khachhangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index", "Trangchu");
            
           
        }
        public ActionResult signout()
        {
            if (Session["nguoidung_khach"] != null)
            {
                Session["nguoidung_khach"] = null;
                return Json(new { success = true, msg = "đăng xuất thành công" }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { msg="Bạn đã đăng xuất rồi", success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}