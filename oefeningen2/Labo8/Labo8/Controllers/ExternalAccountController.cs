using Labo8.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labo8.Controllers
{
    public class ExternalAccountController : Controller
    {
        // GET: ExternalAccount
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string UserName, string Password, string Blocked)
        {
            Boolean isBlocked = false;
            if (Blocked == "on") isBlocked = true;
            DAFileRegistration.SaveUser(UserName, Password, isBlocked);
            return RedirectToAction("Index", "Home");
        }
    }
}