using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labo_01.Controllers
{
    public class DateController : Controller
    {
        // GET: Date
        public ActionResult Today()
        {
            ViewBag.Today = DateTime.Now.ToShortDateString();
            // ViewBag.Today = DateTime.Now.ToShortTimeString();
            //weergeven van enkel de datum

            
            return View();
        }

        public ActionResult Yesterday()
        {
            ViewBag.Yesterday = DateTime.Now.AddDays(-1);
            return View();
        }

        public ActionResult Tomorrow()
        {
            ViewBag.Tomorrow = DateTime.Now.AddDays(1);
            return View();
        }

    }
}