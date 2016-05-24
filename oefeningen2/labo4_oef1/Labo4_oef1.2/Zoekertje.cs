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
        //add ref system data annotations
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "De Korte omschrijving veld is verplicht")]
        [DisplayName("Korte omschrijving (max 100 kar.)")]
        [MaxLengthAttribute(100)]
        public string Titel { get; set; }
        [Required(ErrorMessage = "De Wat zoek ik veld is verplicht")]
        [DisplayName("Wat zoek ik")]
        public string Omschrijving { get; set; }
        [Required(ErrorMessage = "De Naam veld is verplicht")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "De Telefoon veld is verplicht")]
        public string Telefoon { get; set; }
        [Required(ErrorMessage = "De E-Mail veld is verplicht")]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "De Max. prijs die ik wens te betalen veld is verplicht")]
        [DisplayName("Max. prijs die ik wens te betalen")]
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