using Repozytorium.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repozytorium.Models;
using System.Diagnostics;
using Repozytorium.Models.Views;
using System.Data.Entity;

namespace Repozytorium.Repo
{
    public class KategoriaRepo : IKategoriaRepo
    {
        private readonly IOglContext _db;
        public KategoriaRepo(IOglContext db)
        {
            _db = db;
        }

        public void Dodaj(Kategoria kategoria)
        {
            _db.Kategorie.Add(kategoria);
        }

        public Kategoria GetKategoriaById(int id)
        {
            var kategoria = _db.Kategorie.FirstOrDefault(p => p.Id == id);
            return kategoria;
        }

        public void Aktualizuj(Kategoria kategoria)
        {
            _db.Entry(kategoria).State = EntityState.Modified;
        }

        public bool KategoriaIstnieje(string kategoria)
        {
            var m = from o in _db.Kategorie.Where(x => x.Nazwa == kategoria) select o;
            return m == null ? false : true;
        }

        public string NazwaDlaKategorii(int id)
        {
            var nazwa = _db.Kategorie.Find(id).Nazwa;
            return nazwa;
        }

        public IQueryable<KategoriaViewModel> PobierzKategorie()
        {
            var kategorie = from o in _db.Kategorie.Include("Ogloszenie_Kategoria")
                            select new KategoriaViewModel
                            {
                                Id = o.Id,
                                Nazwa = o.Nazwa,
                                Opis = o.MetaOpis,
                                LiczbaOfert = o.Ogloszenie_Kategoria.Select(p => p.OgloszenieId).Count(),
                            };
            return kategorie.ToList().AsQueryable();
        }

        public IQueryable<KategoriaCVViewModel> PobierzKategorieCV()
        {
            var kategorie = from o in _db.Kategorie.Include("CV")
                            select new KategoriaCVViewModel
                            {
                                Id = o.Id,
                                Nazwa = o.Nazwa,
                                Opis = o.MetaOpis,
                                LiczbaOfert = o.CV.Select(p => p.KategoriaId).Count(),
                            };
            return kategorie.ToList().AsQueryable();
        }

        public IQueryable<Kategoria> PobierzStrone(int? page = 1, int? pageSize = 10)
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var kategorie = _db.Kategorie.AsNoTracking().Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);
            return kategorie;
        }

        public IQueryable<OgloszeniaZKategoriiViewModels> PobierzOgloszeniaZKategorii(int id)
        {
            var ogloszeniaList = new List<OgloszeniaZKategoriiViewModels>();
            var ogloszenia = from o in _db.Ogloszenia.Include("Uzytkownik").Include("Miasto").Include("Ogloszenie_Kategoria")
                             join k in _db.Ogloszenie_Kategoria on o.Id equals k.OgloszenieId
                             where o.Zaakceptowane == true && o.DataWaznosci > DateTime.Now  && k.KategoriaId == id
                             orderby o.DataDodania
                             select new
                             {
                                 UzytkownikId = o.UzytkownikId,
                                 Firma = o.Uzytkownik.Firma,
                                 IdOgloszenia = o.Id,
                                 Tytul = o.Tytul,
                                 Miasto = o.Miasto.Nazwa,
                                 RodzajUmowy = o.RodzajUmowy.Nazwa,
                                 DataDodania = o.DataDodania,
                                 NazwaKategorii = _db.Kategorie.Where(q => q.Id == id).Select(p => p.Nazwa).FirstOrDefault()
                             };
            var x = ogloszenia.ToList();
            foreach (var ogloszenie in x)
            {
                ogloszeniaList.Add(new OgloszeniaZKategoriiViewModels
                {
                    UzytkownikId = ogloszenie.UzytkownikId,
                    Firma = ogloszenie.Firma,
                    IdOgloszenia = ogloszenie.IdOgloszenia,
                    Tytul = ogloszenie.Tytul,
                    Miasto = ogloszenie.Miasto,
                    RodzajUmowy = ogloszenie.RodzajUmowy,
                    DataDodania = ogloszenie.DataDodania,
                    NazwaKategorii = ogloszenie.NazwaKategorii
                });
            }
            return ogloszeniaList.AsQueryable();
        }

        public IQueryable<CVZKategoriiViewModels> PobierzCVZKategorii(int id)
        {
            var CVList = new List<CVZKategoriiViewModels>();
            var CV = from o in _db.Kategorie.Include("Uzytkownik").Include("Kategoria")
                     join k in _db.CV on o.Id equals k.KategoriaId
                     join l in _db.Uzytkownik on k.UzytkownikId equals l.Id
                     where k.Zaakceptowane == true && o.Id == id
                     orderby k.DataDodania
                     select new
                     {
                         UzytkownikId = l.Id,
                                 Imie = l.Imie,
                                 Nazwisko = l.Nazwisko,
                                 IdCV = k.Id,
                                 Tresc = k.Tresc,
                                 Tytul = k.Tytul,
                                 Miasto = l.Miasto,
                                 DataDodania = k.DataDodania,
                                 NazwaKategorii = _db.Kategorie.Where(q => q.Id == id).Select(p => p.Nazwa).FirstOrDefault()
                             };
            var x = CV.ToList();
            foreach (var cv in x)
            {
                CVList.Add(new CVZKategoriiViewModels
                {
                    UzytkownikId = cv.UzytkownikId,
                    Imie = cv.Imie,
                    Nazwisko = cv.Nazwisko,
                    IdCV = cv.IdCV,
                    Tresc = cv.Tresc,
                    Tytul = cv.Tytul,
                    Miasto = cv.Miasto,
                    DataDodania = cv.DataDodania,
                    NazwaKategorii = cv.NazwaKategorii
                });
            }
            return CVList.AsQueryable();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
        
    
