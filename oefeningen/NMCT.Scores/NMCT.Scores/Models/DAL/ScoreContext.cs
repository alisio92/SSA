﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace NMCT.Scores.Models.DAL
{
    public class ScoreContext : DbContext
    {
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}