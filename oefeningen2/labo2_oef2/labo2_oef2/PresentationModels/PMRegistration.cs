using labo2_oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labo2_oef2.PresentationModels
{
    public class PMRegistration
    {
        public Registration NewRegistration { get; set; }
        public SelectList Slot1 { get; set; }
        public SelectList Slot2 { get; set; }
        public SelectList Slot3 { get; set; }
        public SelectList Organisation { get; set; }
    }
}