using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NMCT.Scores.Models.DAL.Repositories
{
    public class ScoreRepository
    {

        public Score GetScore(int id)
        {
            using (ScoreContext context = new ScoreContext())
            {
                var query = (from c in context.Score
                             .Include(c => c.TeamA)
                             .Include(c => c.TeamB)
                             where c.Id == id
                             select c);
                return query.Single<Score>();
            }
        }

        public List<Score> GetScores(int id)
        {
            using (ScoreContext context = new ScoreContext())
            {
                var query = (from c in context.Score
                             .Include(c => c.TeamA)
                             .Include(c => c.TeamB)
                             where c.TeamA.Id == id || c.TeamB.Id == id
                             select c);
                return query.ToList<Score>();
            }
        }

        public void AddScore(Score score)
        {
            using (ScoreContext context = new ScoreContext())
            {
                context.Entry(score).State = EntityState.Added;
                context.Score.Add(score);
                context.SaveChanges();
            }
        }

        public void DeleteScore(Score score)
        {
            using (ScoreContext context = new ScoreContext())
            {
                context.Entry(score).State = EntityState.Deleted;
                context.Score.Remove(score);
                context.SaveChanges();
            }
        }
    }
}