using Repozytorium.IRepo;
using Repozytorium.Models;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class MiastoRepo : IMiastoRepo
    {
        private readonly IOglContext _db;
        public MiastoRepo(IOglContext db)
        {
            _db = db;
        }

        public void Dodaj(Miasto miasto)
        {
            _db.Miasto.Add(miasto);
        }

        public bool MiastoIstnieje(Miasto miasto)
        {
            var m = from o in _db.Miasto.Where(x => x.Nazwa == miasto.Nazwa) select o;
            return m == null ? false : true;
        }

        public IQueryable<MiastoViewModel> PobierzMiasta()
        {
            var miasta = from o in _db.Miasto.Include("Ogloszenie")
                            select new MiastoViewModel
                            {
                                Id = o.Id,
                                Nazwa = o.Nazwa,
                                LiczbaOfert = o.Ogloszenia.Select(p => p.MiastoId).Count(),
                            };
            return miasta.ToList().AsQueryable();
        }

        public IQueryable<OgloszeniaZMiastaViewModel> PobierzOgloszeniaZMiasta(int id)
        {
            var ogloszeniaList = new List<OgloszeniaZMiastaViewModel>();
            var ogloszenia = from o in _db.Ogloszenia.Include("Uzytkownik").Include("Miasto").Include("Ogloszenie_Kategoria")
                             where o.Zaakceptowane == true && o.DataWaznosci > DateTime.Now && o.MiastoId == id
                             orderby o.DataDodania
                             select new
                             {
                                 UzytkownikId = o.UzytkownikId,
                                 Firma = o.Uzytkownik.Firma,
                                 IdOgloszenia = o.Id,
                                 Tytul = o.Tytul,
                                 Miasto = o.Miasto.Nazwa,
                                 RodzajUmowy = o.RodzajUmowy.Nazwa,
                                 DataDodania = o.DataDodania
                             };
            var x = ogloszenia.ToList();
            foreach (var ogloszenie in x)
            {
                ogloszeniaList.Add(new OgloszeniaZMiastaViewModel
                {
                    UzytkownikId = ogloszenie.UzytkownikId,
                    Firma = ogloszenie.Firma,
                    IdOgloszenia = ogloszenie.IdOgloszenia,
                    Tytul = ogloszenie.Tytul,
                    Miasto = ogloszenie.Miasto,
                    RodzajUmowy = ogloszenie.RodzajUmowy,
                    DataDodania = ogloszenie.DataDodania
                });
            }
            return ogloszeniaList.AsQueryable();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}