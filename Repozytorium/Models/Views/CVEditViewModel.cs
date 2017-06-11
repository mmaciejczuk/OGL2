using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models.Views
{
    public class CVEditViewModel
    {
        public List<Miasto> Miasta { get; set; }
        public List<Kategoria> Kategorie { get; set; }
        public List<Doswiadczenie> Doswiadczenie { get; set; }

        public string UzytkownikId { get; set; }
        public int IdCV { get; set; }

        [Display(Name = "Opis:")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Tresc { get; set; }

        [Display(Name = "Tytuł:")]
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Tytul { get; set; }

        [Display(Name = "Miasto:")]
        [Required(ErrorMessage = "Miasto jest wymagane")]
        //public string Miasto { get; set; }
        public int MiastoId { get; set; }

        [Display(Name = "Kategoria:")]
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        //public string RodzajUmowy { get; set; }
        public int KategoriaId { get; set; }

        [Display(Name = "Wymagania:")]
        [Required(ErrorMessage = "Wypełnij pole")]
        public string Wymagania { get; set; }

        public DateTime DataDodania { get; set; }

        [Display(Name = "Zaakceptowane:")]
        public bool Zaakceptowane { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
    }
}