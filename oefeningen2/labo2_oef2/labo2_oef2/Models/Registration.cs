using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace labo2_oef2.Models
{
    public class Registration
    {
        [Required]
        [MaxLength(130)]
        public string Name { get; set;}
        [Required]
        [MaxLength(130)]
        public string FirstName { get; set; }
        [Required]
        [Range(18,130)]
        public string Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Slot1 { get; set; }
        [Required]
        public string Slot2 { get; set; }
        [Required]
        public string Slot3 { get; set; }
        public string Laptop { get; set; }
        public string Tablet { get; set; }
        public string Watch { get; set; }
        public string Organisation { get; set; }
        public string Party { get; set; }
    }
}