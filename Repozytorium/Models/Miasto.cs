using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Miasto
    {
        public Miasto()
        {
            this.Ogloszenia = new HashSet<Ogloszenie>();
            this.CV = new HashSet<CV>();
        }

        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa miasta:")]
        [Required]
        public string Nazwa { get; set; }

        public virtual HashSet<Ogloszenie> Ogloszenia { get; set; }
        public virtual HashSet<CV> CV { get; set; }
    }
}