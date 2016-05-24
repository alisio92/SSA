﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMCT.Scores.Models {
    public class Competition
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Score> Scores { get; set; }
        public Country Country { get; set; }

        public string Title
        {
            get { return Name + "(" + Country.Name + ")"; }
        }
    }
}