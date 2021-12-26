using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
using System.IO;
namespace myHondaMVC.Areas.AdminCP.Controllers
{
    public class xemayController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: AdminCP/xemay
        public ActionResult Index()
        {
            var sp = from s in db.xemays select s;
            ViewBag.maloai = new SelectList(db.loaixes, "maloai", "tenloai");
            ViewBag.mancc = new SelectList(db.nhacungcaps, "mancc", "tenncc");
            return View(sp);
        }
        public ActionResult Xemchitiet(int id)
        {
            xemay sp = db.xemays.Find(id);
            ViewBag.maloai = new SelectList(db.loaixes, "maloai", "tenloai", sp.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcaps, "mancc", "tenncc", sp.mancc);
           
            return View(sp);
        }
        public ActionResult Create(int mancc,int maloai,string tenxe,double gianhap,double giaban,string khungxe,string mausac,string khoiluong,string dungtichxylanh,string dongco,string muctieuthunguyenlieu,string phuoctruoc,string phuocsau,string ghichu,string mota,int soluong,HttpPostedFileBase img)
        {
            xemay xm = new xemay();
            xm.mancc = mancc;
            xm.maloai = maloai;
            xm.tenxe = tenxe;
            xm.gianhap = gianhap;
            xm.giaban = giaban;
            xm.giakhuyenmai = 0;
            xm.status = true;
            xm.khungxe = khungxe;
            xm.mausac = mausac;
            xm.khoiluong = khoiluong;
            xm.dungtichxylanh = dungtichxylanh;
            xm.dongco = dongco;
            xm.muctieuthunguyenlieu = muctieuthunguyenlieu;
            xm.phuoctruoc = phuoctruoc;
            xm.ngaythem = DateTime.Now;
            xm.phuocsau = phuocsau;
            xm.ghichu = ghichu;
            xm.mota = mota;
            xm.soluong = soluong ;
            if (img != null && img.ContentLength > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                xm.img = filename;
                var path = Path.Combine(Server.MapPath("~/Image/"), filename);
                img.SaveAs(path);
            }
            db.xemays.Add(xm);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int maxe,int mancc, int maloai, string tenxe, double gianhap, double giaban, string khungxe, string mausac, string khoiluong, string dungtichxylanh, string dongco, string muctieuthunguyenlieu, string phuoctruoc, string phuocsau, string ghichu, string mota, int soluong, HttpPostedFileBase img)
        {
            xemay xm = db.xemays.Find(maxe);
            xm.mancc = mancc;
            xm.maloai = maloai;
            xm.tenxe = tenxe;
            xm.gianhap = gianhap;
            xm.giaban = giaban;
            xm.giakhuyenmai = 0;
            xm.status = true;
            xm.khungxe = khungxe;
            xm.mausac = mausac;
            xm.khoiluong = khoiluong;
            xm.dungtichxylanh = dungtichxylanh;
            xm.dongco = dongco;
            xm.muctieuthunguyenlieu = muctieuthunguyenlieu;
            xm.phuoctruoc = phuoctruoc;
            xm.ngaythem = DateTime.Now;
            xm.phuocsau = phuocsau;
            xm.ghichu = ghichu;
            xm.mota = mota;
            xm.soluong = soluong;
            if (img != null && img.ContentLength > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                xm.img = filename;
                var path = Path.Combine(Server.MapPath("~/Image/"), filename);
                img.SaveAs(path);
            }
           
            db.Entry(xm).State = System.Data.Entity.EntityState.Modified;
            db.Entry(xm).Property(x => x.mota).IsModified = false;
            db.SaveChanges();
            return RedirectToAction("Xemchitiet","xemay", new { id = maxe });
        }

        public JsonResult Delete(int id)
        {
            try
            {
                 xemay xm = db.xemays.Find(id);
                db.xemays.Remove(xm);
                db.SaveChanges();

                return Json(new { success = true, ms = "xóa thành công " + xm.tenxe }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, ms = "xảy ra lỗi khi truy cấp csdl " }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}