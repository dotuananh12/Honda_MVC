using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.Page.Controllers
{
    public class DanhsachController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: Page/Danhsach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chitiet(int id)
        {
            if (id != 0)
            {
                var ds = db.xemays.Where(x => x.maxe == id).SingleOrDefault();
                return View(ds);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Danhmucloai(int id)
        {
            var rs = db.loaixes.Find(id);
            ViewBag.Title = rs.tenloai;
            return View(db.xemays.Where(x => x.maloai == id));
        }
        public ActionResult Search_product(string sp)
        {
            ViewBag.sp = sp;
            return View(db.xemays.OrderByDescending(x => x.ngaythem).Where(x => x.tenxe.Contains(sp)));
        }
        [HttpPost]
        public ActionResult Search(string search)
        {
            return RedirectToAction("Search_product", "Danhsach", new { sp = search });
        }
    }
}