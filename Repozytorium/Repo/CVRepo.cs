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

            var ogloszenia = from o in _db.CV.Include("Uzytkownik")
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
                                 Miasto = o.Uzytkownik.Miasto,
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
    }
}