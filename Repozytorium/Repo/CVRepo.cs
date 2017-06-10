using Repozytorium.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repozytorium.Models.Views;

namespace Repozytorium.Repo
{
    public class CVRepo : ICVRepo
    {
        private readonly IOglContext _db;
        public CVRepo(IOglContext db)
        {
            _db = db;
        }

        public IQueryable<CVViewModel> PobierzCV()
        {
            var cvList = new List<CVViewModel>();

            var ogloszenia = from o in _db.CV.Include("Miasto")
                             where o.Zaakceptowane == true 
                             orderby o.DataDodania
                             select new
                             {
                                 UzytkownikId = o.UzytkownikId,
                                 Imie = o.Uzytkownik.Imie,
                                 Nazwisko = o.Uzytkownik.Nazwisko,
                                 IdCV = o.Id,
                                 Tresc = o.Tresc,
                                 Tytul = o.Tytul,
                                 Miasto = o.Miasto.Nazwa,
                                 DataDodania = o.DataDodania
                             };
            var x = ogloszenia.ToList();
            foreach (var ogloszenie in x)
            {
                cvList.Add(new CVViewModel
                {
                    UzytkownikId = ogloszenie.UzytkownikId,
                    Imie = ogloszenie.Imie,
                    Nazwisko = ogloszenie.Nazwisko,
                    IdCV = ogloszenie.IdCV,
                    Tresc = ogloszenie.Tresc,
                    Tytul = ogloszenie.Tytul,
                    Miasto = ogloszenie.Miasto,
                    DataDodania = ogloszenie.DataDodania
                });
            }
            return cvList.AsQueryable();
        }
        public OgloszenieEditViewModel GetCVDetailsById(int id)
        {
            var ogloszenie = from o in _db.Ogloszenia.Include("Uzytkownik").Include("Miasto")
                             where o.Zaakceptowane == true && o.DataWaznosci > DateTime.Now
                             orderby o.DataDodania
                             select new OgloszenieEditViewModel
                             {
                                 UzytkownikId = o.UzytkownikId,
                                 Firma = o.Uzytkownik.Firma,
                                 IdOgloszenia = o.Id,
                                 Tresc = o.Tresc,
                                 Tytul = o.Tytul,
                                 MiastoId = o.MiastoId,
                                 RodzajUmowyId = o.RodzajUmowyId,
                                 ZarobkiOd = o.ZarobkiOd,
                                 ZarobkiDo = o.ZarobkiDo,
                                 DataDodania = o.DataDodania
                             };
            var x = ogloszenie.Where(p => p.IdOgloszenia == id).FirstOrDefault();
            return x;
        }

        public CVViewModel GetCVById(int? id)
        {
            var ogloszenie = from o in _db.CV.Include("Miasto")
                             where o.Zaakceptowane == true
                             select new CVViewModel
                             {
                                 IdCV = o.Id,
                                 UzytkownikId = o.UzytkownikId,
                                 Imie = o.Uzytkownik.Imie,
                                 Nazwisko = o.Uzytkownik.Nazwisko,
                                 Tresc = o.Tresc,
                                 Tytul = o.Tytul,
                                 Miasto = o.Miasto.Nazwa,
                                 DataDodania = o.DataDodania
                             };
            var x = ogloszenie.Where(p => p.IdCV == id).FirstOrDefault();
            return x;
        }

        public int GetCVByGuid(string guid)
        {
            var id = from o in _db.CV.Where(p => p.UzytkownikId == guid) 
                     select o.Id;
            return Convert.ToInt32(id.FirstOrDefault());
        }
    }
}