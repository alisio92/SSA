using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasis.Models;//Domain
using MvcBasis.Models.DAL;//ListDomainData

namespace MvcBasis.Controllers
{
    public class DomainController : Controller
    {
        private DomainListRepository _dal;

        public DomainController()
        {
            _dal = new DomainListRepository();
        }

        //
        // GET: /Domain/

        public ActionResult Index()
        {
            return View(_dal.Domains);
        }

        //
        // GET: /Domain/Details/5

        public ActionResult Details(int id)
        {
            var domain = _dal.FindById(id);

            if (domain == null)
            {
                return View("NotFound");
            }

            return View(domain);
        }

        //
        // GET: /Domain/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Domain/Create
        [HttpPost]
        public ActionResult Create(Domain domain)
        {
            if (ModelState.IsValid)
                _dal.Insert(domain);

            return RedirectToAction("index");
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Domain/Edit/5

        public ActionResult Edit(int id)
        {
            var domain = _dal.FindById(id);

            if (domain == null)
            {
                return View("NotFound");
            }

            return View(domain);
        }

        //
        // POST: /Domain/Edit/5
        [HttpPost]
        public ActionResult Edit(Domain domain)
        {
            //domain.Id =  Convert.ToInt32(Request.Form["Id"]);
            //domain.Code = Request.Form["Code"];
            //domain.Name = Request.Form["Name"];
            //domain.Description = Request.Form["Description"];
            //domain.Year = Convert.ToDateTime(Request.Form["Year"]);

            if(ModelState.IsValid)
                _dal.Update(domain);

            return RedirectToAction("Index");  
        }

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Domain/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Domain/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Select()
        {
            PersonTypeRepository lstPersonTypes = new PersonTypeRepository();
            ViewBag.TypeList = new SelectList(lstPersonTypes.PersonTypes, "Name", "Name");
            return View(_dal.Domains);
        }

        [HttpPost]
        public ViewResult Select(Models.PersonType cboTypes, FormCollection collection)
        {
            return View("Thanks", collection);
        }
    }
}
