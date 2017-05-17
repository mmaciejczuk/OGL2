using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IOgloszenieRepo
    {
        IQueryable<Ogloszenie> PobierzOgloszenia();
        Ogloszenie GetOgloszeniaById(int id);
        void UsunOgloszenie(int id);
        void SaveChages();
        void Dodaj(Ogloszenie ogloszenie);
        void Aktualizuj(Ogloszenie ogloszenie);
        IQueryable<Ogloszenie> PobierzStrone(int? page, int? pageSize);
    }
}