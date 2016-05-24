using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;

namespace labo4_oef1Versie2.Controllers
{
    public class ZoekertjeJsonController : ApiController
    {
        // GET: ZoekertjeJson

        public IEnumerable<Zoekertje> Get()
        {
            return Data.GetZoekertjes();
        }
        public HttpResponseMessage Post(Zoekertje zoekertje)
        {
            if (zoekertje == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                Data.AddZoekertje(zoekertje);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}