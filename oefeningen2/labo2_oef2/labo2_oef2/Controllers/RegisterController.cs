using labo2_oef2.PresentationModels;
using Oefening_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo2_oef2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Show()
        {
            PMRegistration pm = new PMRegistration();
            pm.NewRegistration = new Models.Registration();
            pm.Slot1 = new SelectList(Data.GetSessions(1), "id", "Name");
            pm.Slot2 = new SelectList(Data.GetSessions(2), "id", "Name");
            pm.Slot3 = new SelectList(Data.GetSessions(3), "id", "Name");
            pm.Organisation = new SelectList(Data.GetOrganizations(), "id", "Name");
            return View(pm);
        }
    }
}