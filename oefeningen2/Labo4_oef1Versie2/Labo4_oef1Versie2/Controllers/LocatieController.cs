using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;

namespace Labo4_oef1Versie2.Controllers
{
    public class LocatieController : ApiController
    {
        // GET: Locatie
        public List<Locatie> Get()
        {
            return Data.GetLocaties();
        }
    }
}