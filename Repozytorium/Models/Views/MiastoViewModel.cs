using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class MiastoViewModel
    {
        [Display(Name = "Id Miasta:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa miasta:")]
        public string Nazwa { get; set; }
        [Display(Name = "Liczba ofert:")]
        public int LiczbaOfert { get; set; }
    }
}