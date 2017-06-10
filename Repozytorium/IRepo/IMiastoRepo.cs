using Repozytorium.Models;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IMiastoRepo
    {
        IQueryable<MiastoViewModel> PobierzMiasta();
        IQueryable<MiastoViewModel> PobierzMiastaCV();
        IQueryable<OgloszeniaZMiastaViewModel> PobierzOgloszeniaZMiasta(int id);
        void Dodaj(Miasto miasto);
        bool MiastoIstnieje(Miasto miasto);
        Miasto GetMiastoById(int id);
        void Aktualizuj(Miasto miasto);
        void UsunMiasto(int id);
        void SaveChanges();
    }
}