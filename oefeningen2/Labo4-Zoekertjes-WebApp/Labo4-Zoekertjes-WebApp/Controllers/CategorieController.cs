using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoekertjes.Models;
using Zoekertjes.WebApp.DataAccess;

namespace Labo4_Zoekertjes_WebApp.Controllers
{
    public class CategorieController : ApiController
    {
        // GET api/<controller>
        public List<Categorie> Get()
        {
            return Data.GetCategories();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}