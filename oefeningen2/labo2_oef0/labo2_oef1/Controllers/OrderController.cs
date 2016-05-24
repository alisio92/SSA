using labo2_oef1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo2_oef1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Bestel(int? step)
        {
            if (!step.HasValue)
            {
                return RedirectToAction("New");
            }
            switch(step.Value){
                case 1:
                    {
                        return View("Step1");
                    }
                case 2:
                    {
                        String naam = Request.Form["name"];
                        String voornaam = Request.Form["firstName"];
                        String bedrijf = Request.Form["company"];
                        ViewBag.Naam = naam;
                        ViewBag.Voornaam = voornaam;
                        ViewBag.Bedrijf = bedrijf;
                        ViewBag.Tablets = fillTablets();
                        return View("Step2");
                    }
                case 3:
                    {
                        String naam = Request.Form["name"];
                        String voornaam = Request.Form["firstName"];
                        String bedrijf = Request.Form["company"];
                        return View("Step3");
                    }
                default: return RedirectToAction("New");
            }
        }

        private List<Tablet> fillTablets()
        {
            List<Tablet> returnValue = new List<Tablet>();
            returnValue.Add(new Tablet() {Id = 1, Name = "t1" });
            returnValue.Add(new Tablet() { Id = 2, Name = "t2" });
            returnValue.Add(new Tablet() { Id = 3, Name = "t3" });
            return returnValue;
        }
    }
}