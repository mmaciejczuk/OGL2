using Repozytorium.Models;
using Repozytorium.Models.Views;
using System.Linq;

namespace Repozytorium.IRepo
{
    public interface IOgloszenieRepo
    {
        IQueryable<OgloszeniaViewModel> PobierzOgloszenia();
        Ogloszenie GetOgloszeniaById(int id);
        void UsunOgloszenie(int id);
        void SaveChages();
        void Dodaj(Ogloszenie ogloszenie);
        void Aktualizuj(Ogloszenie ogloszenie);
        IQueryable<OgloszeniaViewModel> PobierzStrone(int? page, int? pageSize);
    }
}