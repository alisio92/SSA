using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.WebApp.Models;

namespace labo4_oef1.PresentationModels
{
    public class PMNew : Zoekertje
    {
        public SelectList NewCategory { get; set; }
        public SelectList NewLocation { get; set; }
    }
}