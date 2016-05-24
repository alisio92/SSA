using labo1_oef3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo1_oef3.Controllers
{
    public class ServerVariablesController : Controller
    {
        // GET: ServerVariables
        public ActionResult SV()
        {
            //ViewBag.sv = Request.ServerVariables.AllKeys;
            //ViewBag.values = Request.ServerVariables;

            List<Variables> list = new List<Variables>();
            foreach (string Variable in Request.ServerVariables.AllKeys)
            {
                var value = Request.ServerVariables[Variable];

                Variables sv = new Variables();
                sv.Variable = Variable;
                sv.Values = value;
                list.Add(sv);
            }



            ViewBag.Info = list;

            return View();
        }
    }
}