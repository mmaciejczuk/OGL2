using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repozytorium.Models.Views
{
    public class OgloszeniaViewModel
    {
        public string UzytkownikId { get; set; }
        public string Firma { get; set; }
        public int IdOgloszenia { get; set; }
        public string Tresc { get; set; }
        public string Tytul { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime DataWaznosci { get; set; }

        public string GetFormattedDateAdd { get { return this.DataDodania.ToString("dd-MM-yyyy"); } }
        public DateTime GetFormattedDateExp { get; set; }
    }
}