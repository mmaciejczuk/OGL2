using Repozytorium.Models;
using Repozytorium.Models.Views;
using System.Linq;

namespace Repozytorium.IRepo
{
    public interface IOgloszenieRepo
    {
        IQueryable<OgloszenieViewModel> PobierzOgloszenia();
        OgloszenieViewModel GetOgloszeniaById(int id);
        void UsunOgloszenie(int id);
        void SaveChages();
        void Dodaj(Ogloszenie ogloszenie);
        void Aktualizuj(Ogloszenie ogloszenie);
        IQueryable<OgloszenieViewModel> PobierzStrone(int? page, int? pageSize);
    }
}