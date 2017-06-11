using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Edukacja
    {
        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa szkoły:")]
        [MaxLength(500)]
        public string Szkola { get; set; }
        [Display(Name = "Tytul naukowy:")]
        [MaxLength(72)]
        public string Tytul { get; set; }
        [Display(Name = "Data rozpoczęcia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataRozpoczecia { get; set; }
        [Display(Name = "Data zakończenia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataZakonczenia { get; set; }
        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}