using Repozytorium.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repozytorium.Models;
using System.Diagnostics;

namespace Repozytorium.Repo
{
    public class KategoriaRepo : IKategoriaRepo
    {
        private readonly IOglContext _db;
        public KategoriaRepo(IOglContext db)
        {
            _db = db;
        }

        public string NazwaDlaKategorii(int id)
        {
            var nazwa = _db.Kategorie.Find(id).Nazwa;
            return nazwa;
        }

        public IQueryable<Kategoria> PobierzKategorie()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var kategorie = _db.Kategorie.AsNoTracking();
            return kategorie;
        }

        public IQueryable<Kategoria> PobierzStrone(int? page = 1, int? pageSize = 10)
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var kategorie = _db.Kategorie.AsNoTracking().Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);
            return kategorie;
        }

        public IQueryable<Ogloszenie> PobierzOgloszeniaZKategorii(int id)
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var ogloszenia = from o in _db.Ogloszenia
                             join k in _db.Ogloszenie_Kategoria on o.Id equals k.OgloszenieId
                             where k.KategoriaId == id
                             select o;
            var ogloszenia2 = ogloszenia.ToList();
            return ogloszenia;
        }
    }
}
        
    
