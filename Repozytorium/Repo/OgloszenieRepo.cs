using Repozytorium.IRepo;
using Repozytorium.Models;
using System.Diagnostics;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Data.Entity;
using Repozytorium.Models.Views;
using System.Collections.Generic;
using AutoMapper;

namespace Repozytorium.Repo
{
    public class OgloszenieRepo : IOgloszenieRepo
    {
        private readonly IOglContext _db;
        //private readonly IMappingService _mapper;
        public OgloszenieRepo(IOglContext db)
        {
            _db = db;
        }

        public void Aktualizuj(Ogloszenie ogloszenie)
        {
            _db.Entry(ogloszenie).State = EntityState.Modified;
        }

        public void Dodaj(Ogloszenie ogloszenie)
        {
            _db.Ogloszenia.Add(ogloszenie);
        }

        public Ogloszenie GetOgloszeniaById(int id)
        {
            Ogloszenie ogloszenie = _db.Ogloszenia.Find(id);
            return ogloszenie;
        }

        public IQueryable<OgloszeniaViewModel> PobierzOgloszenia()
        {
            var ogloszeniaList = new List<OgloszeniaViewModel>();
            //_db.Database.Log = message => Trace.WriteLine(message);
            //var ogloszenia = _db.Ogloszenia.AsNoTracking();
            //return ogloszenia;

            var ogloszenia = from o in _db.Ogloszenia.Include("Uzytkownik")
                            
                             select new
                                        {
                                            UzytkownikId = o.Id.ToString(),
                                            Firma = o.Uzytkownik.Firma,
                                            IdOgloszenia = o.Id,
                                            Tresc = o.Tresc,
                                            Tytul = o.Tytul,
                                            DataDodania = o.DataDodania,
                                            DataWaznosci = o.DataWaznosci
                                        };
            var x = ogloszenia.ToList();
            foreach (var ogloszenie in x)
            {
                ogloszeniaList.Add(new OgloszeniaViewModel 
                {
                    UzytkownikId = ogloszenie.UzytkownikId,
                    Firma = ogloszenie.Firma,
                    IdOgloszenia = ogloszenie.IdOgloszenia,
                    Tresc = ogloszenie.Tresc,
                    Tytul = ogloszenie.Tytul,
                    DataDodania = ogloszenie.DataDodania,
                    DataWaznosci = ogloszenie.DataWaznosci
                });
            }            
            return ogloszeniaList.AsQueryable();
        }

        public IQueryable<OgloszeniaViewModel> PobierzStrone(int? page = 1, int? pageSize = 10)
        {
            //var ogloszenia = _db.Ogloszenia
            //    .OrderByDescending(o => o.DataDodania)
            //    .Skip((page.Value - 1) * pageSize.Value)
            //    .Take(pageSize.Value);
            //return ogloszenia;
            return null;
        }

        public void SaveChages()
        {
            _db.SaveChanges();
        }

        public void UsunOgloszenie(int id)
        {
            UsunPowiazanieOgloszenieKategoria(id);
            Ogloszenie ogloszenie = _db.Ogloszenia.Find(id);
            _db.Ogloszenia.Remove(ogloszenie);
        }

        public void UsunPowiazanieOgloszenieKategoria(int id)
        {
            var powiazaneOgloszenia =
                _db.Ogloszenie_Kategoria.Where(o => o.OgloszenieId == id);
             foreach (var ok in powiazaneOgloszenia)
            {
                _db.Ogloszenie_Kategoria.Remove(ok);
            }
        }
    }
}