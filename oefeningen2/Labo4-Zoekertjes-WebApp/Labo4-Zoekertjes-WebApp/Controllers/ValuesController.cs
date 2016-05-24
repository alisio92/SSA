using Labo4_Zoekertjes_WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoekertjes.Models;
using Zoekertjes.WebApp.DataAccess;

namespace Labo4_Zoekertjes_WebApp
{
    public class ValuesController : ApiController
    {
        private static List<Zoekertje> zoekertjes = new List<Zoekertje>();
        public List<Zoekertje> Get()
        {
            
            foreach (var zoeker in Data.GetZoekertjes())
            {
                Zoekertje zkr = new Zoekertje();
                zkr.Id = zoeker.Id;
                zkr.Naam = zoeker.Naam;
                zkr.Omschrijving = zoeker.Omschrijving;
                zkr.Titel = zoeker.Titel;
                zkr.Prijs = zoeker.Prijs;
                zkr.Email = zoeker.Email;
                zkr.Telefoon = zoeker.Telefoon;
                zkr.CategorieId = zoeker.CategorieId;
                zkr.ContacteerViaEMail = zoeker.ContacteerViaEMail;
                zkr.ContacteerViaTelefoon = zoeker.ContacteerViaTelefoon;
                zkr.LocatieId = zoeker.LocatieId;

                zoekertjes.Add(zkr);
            }
            return zoekertjes;
        }

        

        // POST api/<controller>
        public HttpResponseMessage Post(Zoekertje newZoekertje)
        {
            try
            {
                newZoekertje.Id = zoekertjes.Count + 1;
                zoekertjes.Add(newZoekertje);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
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