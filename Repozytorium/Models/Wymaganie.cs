using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Wymaganie
    {
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Treść wymagania:")]
        [MaxLength(500)]
        public string Tresc { get; set; }

        public virtual Ogloszenie Ogloszenie { get; set; }
    }
}