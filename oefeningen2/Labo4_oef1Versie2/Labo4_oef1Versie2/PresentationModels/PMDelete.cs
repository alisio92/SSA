using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.WebApp.Models;

namespace Labo4_oef1Versie2.PresentationModels
{
    public class PMDelete : Zoekertje
    {
        public SelectList DeleteReden { get; set; }
    }
}