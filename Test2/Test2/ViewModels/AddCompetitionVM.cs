using NMCT.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMCT.Scores.ViewModels
{
    public class AddCompetitionVM
    {
        public Competition NewCompetition { get; set; }
        public SelectList SelectedCountry { get; set; }
    }
}