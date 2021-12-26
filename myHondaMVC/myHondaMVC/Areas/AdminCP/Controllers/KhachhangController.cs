using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.AdminCP.Controllers
{
    public class KhachhangController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: AdminCP/Khachhang
        public ActionResult Index()
        {
            var kh = from k in db.khachhangs select k;
            return View(kh);
        }
        public ActionResult DonhangKH(int id)
        {
            var rs = db.dathangs.Where(x => x.makh == id).ToList();
            var kh = db.khachhangs.Where(x => x.makh == id).SingleOrDefault();
            ViewBag.name = kh.tenkh;
            return View(rs);
        }
    }
}