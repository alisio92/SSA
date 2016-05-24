using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test2;
using Test2.Models.DAL;

namespace NMCT.Scores.Models.DAL.Repositories
{
    public class ScoreRepository
    {

        public Score GetScore(int id)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                var query = (from c in context.Scores
                             .Include(c => c.TeamA)
                             .Include(c => c.TeamB)
                             where c.Id == id
                             select c);
                return query.Single<Score>();
            }
        }

        public List<Score> GetScores(int id)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                var query = (from c in context.Scores
                             .Include(c => c.TeamA)
                             .Include(c => c.TeamB)
                             where c.TeamA.Id == id || c.TeamB.Id == id
                             select c);
                return query.ToList<Score>();
            }
        }

        public void AddScore(Score score)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                context.Entry(score).State = EntityState.Added;
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public void DeleteScore(Score score)
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                context.Entry(score).State = EntityState.Deleted;
                context.Scores.Remove(score);
                context.SaveChanges();
            }
        }
    }
}