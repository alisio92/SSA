using NMCT.Scores.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test2;
using Test2.Models.DAL;

namespace NMCT.Scores.Models
{
    public class CompetitionRepository
    {
        public List<Competition> GetCompetitions()
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                return context.Competitions.Include(c => c.Country).ToList<Competition>();
            }
        }

        public Competition GetCompetition(int id)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                var query = (from c in context.Competitions.Include(c => c.Country)
                             .Include(s => s.Scores.Select(t => t.TeamA))
                             .Include(s => s.Scores.Select(t => t.TeamB))
                             where c.Id == id
                             select c);
                return query.Single<Competition>();
            }
        }

        public void AddCompetition(Competition competition)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                context.Entry(competition).State = EntityState.Added;
                context.Competitions.Add(competition);
                context.SaveChanges();
            }
        }
    }
}