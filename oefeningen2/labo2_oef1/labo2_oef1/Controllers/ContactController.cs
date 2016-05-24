using labo2_oef1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo2_oef1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult New()
        {
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.Title = "Kies een Title";
            return View();
        }

        [HttpPost]
        public ActionResult New(ContactInfo info)
        {
            return View("Details", info);
        }
    }
}