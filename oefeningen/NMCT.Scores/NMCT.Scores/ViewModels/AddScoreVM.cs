using NMCT.Scores.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMCT.Scores.ViewModels
{
    public class AddScoreVM
    {
        public Team NewTeamA { get; set; }
        public Team NewTeamB { get; set; }
        public List<Team> Teams { get; set; }

        [Display(Name = "Team A")]
        public SelectList SelectedTeamA { get; set; }

        [Required]
        [Display(Name = "Score Team A")]
        public int ScoreA { get; set; }

        [Display(Name = "Team B")]
        public SelectList SelectedTeamB { get; set; }

        [Required]
        [Display(Name = "Score Team B")]
        public int ScoreB { get; set; }
        public int CompetitionId { get; set; }
    }
}