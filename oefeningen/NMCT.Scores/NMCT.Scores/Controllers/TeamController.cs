using NMCT.Scores.Models;
using NMCT.Scores.Models.DAL.Repositories;
using NMCT.Scores.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMCT.Scores.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        [HttpGet]
        public ActionResult Index()
        {
            IndexTeamVM vm = new IndexTeamVM();
            vm.Teams = new List<Team>();
            vm.SelectedCompetition = new SelectList(new CompetitionRepository().GetCompetitions(), "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(IndexTeamVM vm)
        {
            vm.Teams = new TeamRepository().GetTeams(vm.NewCompetition.Id);
            vm.SelectedCompetition = new SelectList(new CompetitionRepository().GetCompetitions(), "Id", "Name");
            return View(vm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            List<Score> score = new ScoreRepository().GetScores(id);
            return View(score);
        }
    }
}