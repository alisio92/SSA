using labo4_oef1.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;

namespace labo4_oef1.Controllers
{
    public class ZoekertjesController : Controller
    {
        // GET: Zoekertjes
        public ActionResult Index()
        {
            List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
            alleZoekertjes = Data.GetZoekertjes();
            ViewBag.New = "Nieuwe zoekertje";
            return View(alleZoekertjes);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            Zoekertje zoekertje = Data.GetZoekertje(id.Value);
            ViewBag.Prijs = zoekertje.ToString();
            Categorie categorie = Data.GetCategorie(zoekertje.CategorieId);
            ViewBag.Categorie = categorie.Naam;
            Locatie locatie = Data.GetLocatie(zoekertje.LocatieId);
            ViewBag.Locatie = locatie.Naam;
            ViewBag.Redirect = "<< terug";
            return View(zoekertje);
        }

        public ActionResult New()
        {
            PMNew newZoekertje = new PMNew();
            newZoekertje.NewCategory = new SelectList(Data.GetCategories(), "Id", "Naam");
            newZoekertje.NewLocation = new SelectList(Data.GetLocaties(), "Id", "Naam");
            return View();
        }
    }
}