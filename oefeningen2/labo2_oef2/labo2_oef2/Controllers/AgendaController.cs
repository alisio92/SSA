using labo2_oef2.Models;
using labo2_oef2.PresentationModels;
using Oefening_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo2_oef2.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Show()
        {
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);
            return View(pm);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Show");
            if (id == null) return RedirectToAction("Show");
            Session sessie = Data.GetSession(id.Value);
            return View(sessie);
        }
    }
}