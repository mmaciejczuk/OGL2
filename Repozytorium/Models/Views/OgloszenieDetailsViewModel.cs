using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class OgloszenieDetailsViewModel
    {
        public string UzytkownikId { get; set; }
        [Display(Name = "Nazwa firmy:")]
        [Required(ErrorMessage = "Nazwa firmy jest wymagana")]
        public string Firma { get; set; }
        public int IdOgloszenia { get; set; }
        [Display(Name = "Treść oferty:")]
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Tresc { get; set; }
        [Display(Name = "Tytuł oferty:")]
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Tytul { get; set; }
        [Display(Name = "Miasto:")]
        [Required(ErrorMessage = "Miasto jest wymagane")]
        public string Miasto { get; set; }
        [Display(Name = "Rodzaj umowy:")]
        [Required(ErrorMessage = "Rodzaj umowy jest wymagane")]
        public string RodzajUmowy { get; set; }
        [Display(Name = "Zarobki od:")]
        [Required(ErrorMessage = "Zarobki są wymagane")]
        public decimal ZarobkiOd { get; set; }
        [Display(Name = "Zarobki do:")]
        [Required(ErrorMessage = "Zarobki są wymagane")]
        public decimal ZarobkiDo { get; set; }
        [Display(Name = "Wymagania:")]
        [Required(ErrorMessage = "Wypełnij pole")]
        public string Wymagania { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime DataWaznosci { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
        public DateTime GetFormattedDateExp { get; set; }
        [Display(Name = "Zarobki od:")]
        public string GetEarningsFrom { get { return this.ZarobkiOd.ToString("F"); } }
        [Display(Name = "Zarobki do:")]
        public string GetEarningsTo { get { return this.ZarobkiDo.ToString("F"); } }
    }
}