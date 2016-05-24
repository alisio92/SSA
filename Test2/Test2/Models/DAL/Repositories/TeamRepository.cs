using NMCT.Scores.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2;
using Test2.Models.DAL;

namespace NMCT.Scores.Models
{
    public class TeamRepository
    {
        public List<Team> GetTeams(int competitionId)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                var query = (from c in context.Teams
                             where c.Competition.Id == competitionId
                             select c);
                return query.ToList<Team>();
            }
        }

        public List<Team> GetTeams()
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                return context.Teams.ToList<Team>();
            }
        }

        public Team GetTeam(int id)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                var query = (from c in context.Teams
                             where c.Id == id
                             select c);
                return query.Single<Team>();
            }
        }
    }
}