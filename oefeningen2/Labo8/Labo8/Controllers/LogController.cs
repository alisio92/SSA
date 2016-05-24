using Labo8.DataAcces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labo8.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            List<FileLog> Logs = DAFileRegistration.GetFileRegistration();
            return View();
        }
    }
}