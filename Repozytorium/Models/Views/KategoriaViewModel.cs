using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class KategoriaViewModel
    {
        [Display(Name = "Id kategorii:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa kategorii:")]
        public string Nazwa { get; set; }
        [Display(Name = "Opis kategorii:")]
        public string Opis { get; set; }
        [Display(Name = "Liczba ofert:")]
        public int LiczbaOfert { get; set; }
    }
}