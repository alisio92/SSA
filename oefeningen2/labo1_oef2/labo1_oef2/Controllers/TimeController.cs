using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo1_oef2.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult WhatTime(int? uur, int? min, int? sec)
        {
            if (uur == null || min == null || sec == null) return View("Error");
            ViewBag.Timestamp = string.Format("{0}:{1}:{2}", uur, min, sec);
            return View();
        }

        public ActionResult WhatTime2()
        {
            if (String.IsNullOrEmpty(Request.QueryString["uur"]) || String.IsNullOrEmpty(Request.QueryString["min"]) || String.IsNullOrEmpty(Request.QueryString["sec"]))
            {
                return View("Error");
            }
            int uur, min, sec;

            int.TryParse(Request.QueryString["uur"].ToString(), out uur);
            int.TryParse(Request.QueryString["min"].ToString(), out min);
            int.TryParse(Request.QueryString["sec"].ToString(), out sec);

            ViewBag.Timestamp = string.Format("{0}:{1}:{2}", uur, min, sec);
            return View("WhatTime");
        }
    }
}