using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;

namespace labo4_oef1.Controllers
{
    public class ZoekertjeJsonController : ApiController
    {
        // GET: ZoekertjeJson

        public IEnumerable<Zoekertje> Get()
        {
            return Data.GetZoekertjes();
        }
    }
}