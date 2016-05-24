using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zoekertjes.WebApp.Models
{
    public class Zoekertje
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("The 'korte omschrijving (max 100 kar.)' field is required")]
        [MaxLengthAttribute(100)]
        public string Titel { get; set; 
        }

        [Required]
        [DisplayName("The 'Wat zoek ik' field is required")]
        public string Omschrijving { get; set; }

        [Required]
        [DisplayName("The 'Naam' field is required")]
        public string Naam { get; set; }

        [Required]
        [DisplayName("The 'Telefoon' field is required")]
        public string Telefoon { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("The 'E-Mail' field is required")]
        public string Email { get; set; }

        [Required]
        [DisplayName("The 'Max. prijs die ik wens te betalen' field is required")]
        public decimal Prijs { get; set; }

        [Required]
        [DisplayName("Wat is de categorie van het zoekertje")]
        public int CategorieId { get; set; }

        [Required]
        [DisplayName("Waar kan ik het zoekertje afhalen")]
        public int LocatieId { get; set; }

        [DisplayName("Contacteer me via telefoon")]
        public bool ContacteerViaTelefoon { get; set; }

        [DisplayName("Contacteer me via e-mail")]
        public bool ContacteerViaEMail { get; set; }

        public override string ToString()
        {
            return string.Format("{0} €{1}", Titel, Prijs);
        }
    }
}