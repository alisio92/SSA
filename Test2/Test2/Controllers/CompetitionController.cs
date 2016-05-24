using NMCT.Scores.Models;
using NMCT.Scores.Models.DAL.Repositories;
using NMCT.Scores.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test2.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        [HttpGet]
        public ActionResult Index()
        {
            List<Competition> competitions = new List<Competition>();
            competitions = new CompetitionRepository().GetCompetitions();
            return View(competitions);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Competition competitions = new Competition();
            competitions = new CompetitionRepository().GetCompetition(id);
            if (competitions == null)
                return HttpNotFound();

            return View(competitions);
        }
        [HttpGet]
        public ActionResult AddScore(int competitionId)
        {
            AddScoreVM vm = new AddScoreVM();
            vm.Teams = new TeamRepository().GetTeams(competitionId);
            vm.SelectedTeamA = new SelectList(new TeamRepository().GetTeams(), "Id", "Name");
            vm.SelectedTeamB = new SelectList(new TeamRepository().GetTeams(), "Id", "Name");
            vm.CompetitionId = competitionId;
            return View(vm);
        }

        [HttpGet]
        public ActionResult AddCompetition()
        {
            AddCompetitionVM vm = new AddCompetitionVM();
            vm.SelectedCountry = new SelectList(new CountryRepository().GetCountries(), "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddCompetition(AddCompetitionVM vm)
        {
            if (ModelState.IsValid)
            {
                CompetitionRepository repository = new CompetitionRepository();
                repository.AddCompetition(vm.NewCompetition);
                return RedirectToAction("Index");
            }
            else
            {
                vm.SelectedCountry = new SelectList(new CountryRepository().GetCountries(), "Id", "Name");
                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult AddScore(AddScoreVM vm)
        {
            if (ModelState.IsValid)
            {
                TeamRepository repository = new TeamRepository();
                Score score = new Score();
                score.ScoreA = vm.ScoreA;
                score.ScoreB = vm.ScoreB;
                score.TeamA = repository.GetTeam(vm.NewTeamA.Id);
                score.TeamB = repository.GetTeam(vm.NewTeamB.Id);
                score.CompetitionId = vm.CompetitionId;

                ScoreRepository repos = new ScoreRepository();
                repos.AddScore(score);
                return RedirectToAction("Details", new { id = vm.CompetitionId });
            }
            else
            {
                vm.SelectedTeamA = new SelectList(new TeamRepository().GetTeams(), "Id", "Name");
                vm.SelectedTeamB = new SelectList(new TeamRepository().GetTeams(), "Id", "Name");
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult DeleteScore(int scoreId)
        {
            DeleteScoreVM score = new DeleteScoreVM();
            score.NewScore = new ScoreRepository().GetScore(scoreId);
            return View(score);
        }

        [HttpPost]
        public ActionResult DeleteScore(DeleteScoreVM vm)
        {
            Score score = new ScoreRepository().GetScore(vm.ID);
            switch (vm.SubmitButton)
            {
                case "Verwijder":
                    new ScoreRepository().DeleteScore(score);
                    return RedirectToAction("Details", new { id = vm.CompetitionId });
                case "Annuleer":
                    return RedirectToAction("Details", new { id = vm.CompetitionId });
            }
            return View(vm);
        }
    }
}