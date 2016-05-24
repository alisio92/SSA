using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMCT.Scores.Models.DAL.Repositories
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            using (ScoreContext context = new ScoreContext())
            {
                return context.Countries.ToList<Country>();
            }
        }
    }
}