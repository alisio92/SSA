using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labo_01.Models;

namespace Labo_01.Controllers
{
    public class ServerVariablesController : Controller
    {
        // GET: ServerVariables
        public ActionResult ServerInfo()
        {
            List<Sv> list = new List<Sv>();
                foreach (string key in Request.ServerVariables.AllKeys){
                    var value = Request.ServerVariables[key];

                    Sv sv = new Sv();
                    sv.key = key;
                    sv.value = value;
                    list.Add(sv);
                }

                

                ViewBag.Info = list;
            return View();
        }

  
    }
}