//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int Id { get; set; }
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
        public int CompetitionId { get; set; }
        public Nullable<int> TeamA_Id { get; set; }
        public Nullable<int> TeamB_Id { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public Team TeamA { get; internal set; }
        public Team TeamB { get; internal set; }
    }
}
