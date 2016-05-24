using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasis.Models
{
    public class Domain
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Year { get; set; }
    }
}