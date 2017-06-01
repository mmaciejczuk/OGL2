using Repozytorium.Models;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repozytorium.IRepo
{
    public interface IKategoriaRepo
    {
        IQueryable<KategoriaViewModel> PobierzKategorie();
        IQueryable<Kategoria> PobierzStrone(int? currentPage, int? naStronie);
        IQueryable<OgloszeniaZKategoriiViewModels> PobierzOgloszeniaZKategorii(int id);
        bool KategoriaIstnieje(string kategoria);
        Kategoria GetKategoriaById(int id);
        void Aktualizuj(Kategoria kategoria);
        void Dodaj(Kategoria kategoria);
        void SaveChanges();
        string NazwaDlaKategorii(int id);
    }
}
