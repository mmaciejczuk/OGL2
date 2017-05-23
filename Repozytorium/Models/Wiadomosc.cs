using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Repozytorium.Models
{
    public class Wiadomosc
    {
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Treść wiadomości:")]
        [MaxLength(500)]
        public string Tresc { get; set; }
        [Display(Name = "Tytuł wiadomości:")]
        [MaxLength(72)]
        public string Tytul { get; set; }
        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataDodania { get; set; }
        public string UzytkownikId { get; set; }
        public string NadawcaId { get; set; }
        public string TypOferty { get; set; }
        public int IdOferty { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}