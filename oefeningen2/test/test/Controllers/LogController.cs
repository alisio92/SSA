using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.DataAccess;

namespace test.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            List<FileLog> logs = new List<FileLog>();
            logs = DAFileRegistration.GetLogs();
            ViewBag.Logs = logs;
            return View();
        }
    }
}