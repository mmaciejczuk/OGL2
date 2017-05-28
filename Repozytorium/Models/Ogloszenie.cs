﻿using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class Ogloszenie
    {
        public Ogloszenie()
        {
            this.Ogloszenie_Kategoria = new HashSet<Ogloszenie_Kategoria>();
            this.Wymagania = new HashSet<Wymaganie>();
        }
        [Display(Name = "Id:")]
        public int Id { get; set; }
        [Display(Name = "Treść oferty:")]
        [Required(ErrorMessage ="Treść jest wymagana")]
        public string Tresc { get; set; }
        [Display(Name = "Tytuł oferty:")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Tytul { get; set; }
        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDodania { get; set; }
        public DateTime DataWaznosci { get; set; }
        public string UzytkownikId { get; set; }
        public int MiastoId { get; set; }
        public int RodzajUmowyId { get; set; }
        public decimal ZarobkiOd { get; set; }
        public decimal ZarobkiDo { get; set; }
        public bool? Zaakceptowane { get; set; }

        public virtual ICollection<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }
        public virtual ICollection<Wymaganie> Wymagania { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual Miasto Miasto { get; set; }
        public virtual RodzajUmowy RodzajUmowy { get; set; }
    }
}