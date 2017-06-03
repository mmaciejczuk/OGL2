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
        void SaveChanges();
        void Dodaj(Ogloszenie ogloszenie);
        void Aktualizuj(OgloszenieEditViewModel ogloszenie);
        //IQueryable<OgloszenieViewModel> PobierzStrone(int? page, int? pageSize);
    }
}