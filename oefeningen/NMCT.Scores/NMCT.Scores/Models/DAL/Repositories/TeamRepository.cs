using NMCT.Scores.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMCT.Scores.Models
{
    public class TeamRepository
    {
        public List<Team> GetTeams(int competitionId)
        {
            using (ScoreContext context = new ScoreContext())
            {
                var query = (from c in context.Team
                             where c.Competition.Id == competitionId
                             select c);
                return query.ToList<Team>();
            }
        }

        public List<Team> GetTeams()
        {
            using (ScoreContext context = new ScoreContext())
            {
                return context.Team.ToList<Team>();
            }
        }

        public Team GetTeam(int id)
        {
            using (ScoreContext context = new ScoreContext())
            {
                var query = (from c in context.Team
                             where c.Id == id
                             select c);
                return query.Single<Team>();
            }
        }
    }
}