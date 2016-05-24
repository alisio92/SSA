using Labo4_Zoekertjes_WebApp.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.Models;
using Zoekertjes.WebApp.DataAccess;

namespace Labo4_Zoekertjes_WebApp.Controllers
{
    public class ZoekertjesController : Controller
    {
        // GET: Zoekertjes
        public ActionResult Index()
        {
            List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
            alleZoekertjes = Data.GetZoekertjes();
            return View(alleZoekertjes);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            Zoekertje zoekertje = (Zoekertje)Data.GetZoekertje(id.Value);

            ViewBag.Titel = zoekertje.Titel;
            ViewBag.Beschrijving = zoekertje.Omschrijving;
            ViewBag.Prijs = zoekertje.Prijs;

            if (zoekertje.ContacteerViaEMail == true)
            {
                ViewBag.Email = "Contacteren via email mogelijk op het adres: " + zoekertje.Email;
            }

            if (zoekertje.ContacteerViaTelefoon == true)
            {
                ViewBag.Telefoon = "Contacteren via telefoon mogelijk op het nr: " + zoekertje.Telefoon;
            }

            Categorie categorie = (Categorie)Data.GetCategorie(zoekertje.CategorieId);
            ViewBag.Categorie = categorie.Naam;

            Locatie locatie = (Locatie)Data.GetLocatie(zoekertje.LocatieId);
            ViewBag.Locatie = locatie.Naam;

            return View(zoekertje);
        }

        public ActionResult New()
        {
            PMzoekertje pm = new PMzoekertje();

            pm.ZoekertjeCategories = new SelectList(Data.GetCategories(), "Id", "Naam");
            pm.ZoekertjeLocaties= new SelectList(Data.GetLocaties(), "Id", "Naam");

            return View(pm);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            Zoekertje zoekertje = (Zoekertje)Data.GetZoekertje(id.Value);

            ViewBag.Titel = zoekertje.Titel;
            ViewBag.Beschrijving = zoekertje.Omschrijving;

            return View(zoekertje);
        }
    }
}