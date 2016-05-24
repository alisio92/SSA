using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using test.DataAccess;

namespace test.Controllers
{
    public class LogJsonController : ApiController
    {
        // GET: LogJson
        public IEnumerable<FileLog> Get()
        {
            List<FileLog> logs = DAFileRegistration.GetLogs();
            return logs;
        }
    }
}