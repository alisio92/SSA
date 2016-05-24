using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo1.Controllers
{
    public class DateController : Controller
    {
        // GET: Date
        public ActionResult Today()
        {
            ViewBag.Today = DateTime.Now.ToString();
            return View();
        }

        public ActionResult Tomorow()
        {
            ViewBag.Tomorow = DateTime.Now.AddDays(1).ToString();
            return View();
        }

        public ActionResult Yesterday()
        {
            ViewBag.Yesterday = DateTime.Now.AddDays(-1).ToString();
            return View();
        }
    }
}