using Repozytorium.Models;
using Repozytorium.Models.Views;
using System.Collections.Generic;
using System.Linq;

namespace Repozytorium.IRepo
{
    public interface IOgloszenieRepo
    {
        IQueryable<OgloszenieViewModel> PobierzOgloszenia();
        OgloszenieEditViewModel GetOgloszenieDetailsById(int id);
        OgloszenieDetailsViewModel GetOgloszeniaById(int id);
        List<Miasto> GetCities();
        List<RodzajUmowy> GetAgreementTypes();
        List<Kategoria> GetCategories();
        void UsunOgloszenie(int id);
        void SaveChages();
        void Dodaj(OgloszenieCreateViewModel ogloszenie);
        void Aktualizuj(Ogloszenie ogloszenie);
        //IQueryable<OgloszenieViewModel> PobierzStrone(int? page, int? pageSize);
    }
}