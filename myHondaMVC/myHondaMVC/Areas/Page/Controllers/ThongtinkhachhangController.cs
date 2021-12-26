using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
using System.IO;

namespace myHondaMVC.Areas.Page.Controllers
{
    public class ThongtinkhachhangController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: Page/Thongtinkhachhang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int makh,string tenkh,string pass,string diachi,string phone,HttpPostedFileBase img)
        {
            khachhang nd = db.khachhangs.Find(makh);
            nd.tenkh = tenkh;
            nd.pass = pass;
            nd.diachi = diachi;
            nd.phone = phone;
            if (img != null && img.ContentLength > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                nd.img = filename;
                var path = Path.Combine(Server.MapPath("~/image/"), filename);
                img.SaveAs(path);
            }
            db.Entry(nd).State = System.Data.Entity.EntityState.Modified;//khong sua
            db.SaveChanges();
            var khach = db.khachhangs.Where(x => x.email == nd.email && x.pass == nd.pass).SingleOrDefault();
            Session["nguoidung_khach"] = khach;
            return RedirectToAction("Index");
        }
    }
}