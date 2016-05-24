using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2;
using Test2.Models.DAL;

namespace NMCT.Scores.Models.DAL.Repositories
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            using (ScoreAppContext context = new ScoreAppContext())
            {
                return context.Countries.ToList<Country>();
            }
        }
    }
}