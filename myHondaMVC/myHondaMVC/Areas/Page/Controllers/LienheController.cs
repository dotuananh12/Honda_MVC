using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHondaMVC.Models;
namespace myHondaMVC.Areas.Page.Controllers
{
    public class LienheController : Controller
    {
        myHondacontext db = new myHondacontext();
        // GET: Page/Lienhe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lienhe(lienhe lh)
        {
            lh.ngaygui = DateTime.Now;
            lh.status = false;
            db.lienhes.Add(lh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}