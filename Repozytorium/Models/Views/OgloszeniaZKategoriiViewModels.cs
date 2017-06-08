using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class OgloszeniaZKategoriiViewModels
    {
        public int IdOgloszenia { get; set; }
        public string UzytkownikId { get; set; }
        public string Firma { get; set; }
        public string Tytul { get; set; }
        public string Miasto { get; set; }
        public string RodzajUmowy { get; set; }
        public DateTime DataDodania { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
        public string NazwaKategorii { get; set; }
    }
}