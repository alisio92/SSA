using Labo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labo8.PresentationModels
{
    public class PMIndex : FileRegistration
    {
        public SelectList NewFile { get; set; }
    }
}