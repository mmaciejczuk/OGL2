using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repozytorium.Models.Views
{
    public class OgloszenieViewModel
    {
        public int IdOgloszenia { get; set; }
        public string UzytkownikId { get; set; }
        [Display(Name = "Nazwa firmy:")]
        [Required(ErrorMessage = "Nazwa firmy jest wymagana")]
        public string Firma { get; set; }
        [Display(Name = "Tytuł oferty:")]
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Tytul { get; set; }
        [Display(Name = "Miasto:")]
        [Required(ErrorMessage = "Miasto jest wymagane")]
        public string Miasto { get; set; }
        [Display(Name = "Rodzaj umowy:")]
        [Required(ErrorMessage = "Rodzaj umowy jest wymagane")]
        public string RodzajUmowy { get; set; }
        public DateTime DataDodania { get; set; }
        [Display(Name = "Zaakceptowane:")]
        public bool Zaakceptowane { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
    }
}