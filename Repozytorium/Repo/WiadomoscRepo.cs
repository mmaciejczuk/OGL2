using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class WiadomoscRepo : IWiadomoscRepo
    {
        private readonly IOglContext _db;
        public WiadomoscRepo(IOglContext db)
        {
            _db = db;
        }

        public void SendMessage(string UzytkownikId, int IdOgloszenia, string tresc)
        {
            var messageTo = _db.Ogloszenia.Where(p => p.Id == IdOgloszenia).Select(o => o.UzytkownikId).FirstOrDefault();
            var tytul = _db.Ogloszenia.Where(p => p.Id == IdOgloszenia).Select(o => o.Tytul).FirstOrDefault();
            var uzytkownik = from o in _db.Uzytkownik.Where(p => p.Id == UzytkownikId) select o;
            _db.Wiadomosc.Add(new Wiadomosc()
            {
                Tresc = tresc,
                Tytul = String.Concat("Re: Ogłoszenie nr: ", IdOgloszenia, " - " , tytul.ToString()),
                DataDodania = DateTime.UtcNow,
                UzytkownikId = UzytkownikId,
                NadawcaId = messageTo.ToString(),
                TypOferty = "",
                IdOferty = IdOgloszenia,
                Uzytkownik = uzytkownik as Uzytkownik,
            });
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}