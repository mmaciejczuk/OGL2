using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Doswiadczenie
    {
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa firmy:")]
        [MaxLength(500)]
        public string Firma { get; set; }
        [Display(Name = "Stanowiusko:")]
        [MaxLength(72)]
        public string Stanowisko { get; set; }
        [Display(Name = "Data rozpoczęcia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataRozpoczecia { get; set; }
        [Display(Name = "Data zakończenia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataZakonczenia { get; set; }
        public string CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}