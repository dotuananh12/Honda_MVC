using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
using myHondaMVC.Areas.Page.Models;
namespace myHondaMVC.Areas.Page.Controllers
{
    public class GiohangController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: Page/Giohang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCart(int id)
        {
            if (Session["giohang"] == null) 
            {
                Session["giohang"] = new List<CartItem>();  
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  
                                                                           
            if (giohang.FirstOrDefault(m => m.id == id) == null) 
            {
                xemay sp = db.xemays.Find(id);
                CartItem newItem = new CartItem()
                {
                    id = id,
                    tensp = sp.tenxe,
                    dongia = sp.giaban,
                    img = sp.img,
                    soluong = 1

                };
                giohang.Add(newItem);  
            }
            else
            {
              
                return Json(new { success = false, ms = "Sản phẩm đã có trong giỏ hàng rồi" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, ms = "đã thêm vào giỏ hàng" }, JsonRequestBehavior.AllowGet);
        }


        //load giỏ hàng
        public ActionResult LoadCart()
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            if (giohang.Count() > 0)
            {
                int thanhtien = giohang.Sum(s => s.ThanhTien);
                int soluong = giohang.Sum(x => x.soluong);
                return Json(new { success = true, dt = giohang, thanhtien = thanhtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            

        }
        public ActionResult Incart(int id)
        {
            var sp = db.xemays.Find(id);
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemin = giohang.FirstOrDefault(x => x.id == id);
            if (itemin != null)
            {
                if (sp.soluong > itemin.soluong)
                {
                    itemin.soluong++;

                }
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Outcart(int id)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemout = giohang.FirstOrDefault(m => m.id == id);
            if (itemout != null)
            {
                if (itemout.soluong > 1)
                {
                    itemout.soluong--;
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCart(int id)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem item = giohang.FirstOrDefault(m => m.id == id);
            if (item != null)
            {
                giohang.Remove(item);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ktragio()
        {
            if (Session["giohang"] == null)
            {
                return Json(new { success = 1, msg = "giỏ hàng rỗng" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<CartItem> giohang = Session["giohang"] as List<CartItem>;
                if (giohang.Count() == 0)
                {
                    return Json(new { success = 1, msg = "giỏ hàng rỗng" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (Session["nguoidung_khach"] == null)
                    {
                        return Json(new { success = 2, msg = "bạn cần đăng nhập" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = 3 }, JsonRequestBehavior.AllowGet);
                    }
                }

            }
        }
    }
}