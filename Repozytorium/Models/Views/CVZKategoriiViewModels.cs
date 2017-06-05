using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class CVZKategoriiViewModels
    {
        public string UzytkownikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IdCV { get; set; }
        public string Tresc { get; set; }
        public string Tytul { get; set; }
        public string Miasto { get; set; }
        public DateTime DataDodania { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
        public string GetUserName { get { return string.Concat(this.Imie, " ", this.Nazwisko); } }
        public string NazwaKategorii { get; set; }
    }
}