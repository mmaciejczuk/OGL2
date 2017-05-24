using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class RodzajUmowy
    {
        public RodzajUmowy()
        {
            this.Ogloszenia = new HashSet<Ogloszenie>();
        }

        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Rodzaj umowy:")]
        [Required]
        public string Nazwa { get; set; }

        public virtual HashSet<Ogloszenie> Ogloszenia { get; set; }
    }
}