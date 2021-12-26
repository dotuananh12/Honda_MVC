using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
using myHondaMVC.Areas.Page.Models;

namespace myHondaMVC.Areas.Page.Controllers
{
    public class ThanhtoanController : Controller
    {
        // GET: Page/Thanhtoan
        myHondacontext db = new myHondacontext();
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }
        public JsonResult Dathang(string tenkh,string email,string phone,string diachi,string ghichu)
        {
            try
            {
                dathang dh = new dathang();
                List<CartItem> giohang = Session["giohang"] as List<CartItem>;
                Random rd = new Random();
                nhaplai:
                dh.madh = rd.Next(1000, 1999);
                if (db.dathangs.Count(x => x.madh == dh.madh) > 0)
                {
                    goto nhaplai;
                }
                khachhang kh = (khachhang)Session["nguoidung_khach"];
                dh.makh = kh.makh;
                dh.tenkh = tenkh;
                dh.email = email;
                dh.phone = phone;
                dh.diachi = diachi;
                dh.ghichu = ghichu;
                dh.tongtien = giohang.Sum(x => x.ThanhTien);
                dh.status = 1;
                dh.ngaytao = DateTime.Now;
                db.dathangs.Add(dh);
                db.SaveChanges();
                foreach (var item in giohang)
                {
                    chitietdathang ct = new chitietdathang();
                    ct.madh = dh.madh;
                    ct.maxe = item.id;
                    ct.giaban = item.dongia;
                    ct.soluong = item.soluong;
                    ct.ngaydat = DateTime.Now;
                    db.chitietdathangs.Add(ct);
                    db.SaveChanges();
                }
                return Json(new { success = true, msg = "đặt hàng thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, msg = "đặt hàng thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Cleargio()
        {
            if (Session["giohang"] != null)
            {
                Session["giohang"] = null;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}