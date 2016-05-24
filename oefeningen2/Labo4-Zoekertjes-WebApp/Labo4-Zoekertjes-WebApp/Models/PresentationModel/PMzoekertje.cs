using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.Models;

namespace Labo4_Zoekertjes_WebApp.PresentationModel
{
    public class PMzoekertje
    {
        public Zoekertje NewZoekertje { get; set; }

        public SelectList ZoekertjeCategories { get; set; }

        public SelectList ZoekertjeLocaties { get; set; }
    }
}