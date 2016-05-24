using NMCT.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMCT.Scores.ViewModels
{
    public class IndexTeamVM
    {
        public Competition NewCompetition { get; set; }

        public SelectList SelectedCompetition{ get; set; }

        public List<Team> Teams { get; set; }
    }
}