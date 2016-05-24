using NMCT.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2;

namespace NMCT.Scores.ViewModels
{
    public class DeleteScoreVM
    {
        public int ID { get; set; }

        public int CompetitionId { get; set; }
        public Score NewScore { get; set; }
        public string SubmitButton { get; set; }
    }
}