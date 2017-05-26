using System.Data.Entity;
using System.Web.Mvc;
using Repozytorium.Repo;
using Repozytorium.Models;
using Repozytorium.IRepo;
using Repozytorium.Models.Views;
using System.Linq;
using System;
using PagedList;

namespace OGL2.Controllers
{
    public class KategoriaController : Controller
    {
        private readonly IKategoriaRepo _repo;
        public KategoriaController(IKategoriaRepo repo)
        {
            _repo = repo;
        }
        // GET: Kategoria
        public ActionResult Index(int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int naStronie = 12;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazwaSort = sortOrder == "NazwaAsc" ? "Nazwa" : "NazwaAsc";
            ViewBag.OpisSort = sortOrder == "OpisAsc" ? "Opis" : "OpisAsc";
            ViewBag.IloscOfertSort = sortOrder == "IloscOfertAsc" ? "IloscOfert" : "IloscOfertAsc";

            var kategorie = _repo.PobierzKategorie();

            switch (sortOrder)
            {
                case "Nazwa":
                    kategorie = kategorie.OrderByDescending(s => s.Nazwa);
                    break;
                case "NazwaAsc":
                    kategorie = kategorie.OrderBy(s => s.Nazwa);
                    break;

                case "Opis":
                    kategorie = kategorie.OrderByDescending(s => s.Nazwa);
                    break;
                case "OpisAsc":
                    kategorie = kategorie.OrderBy(s => s.Opis);
                    break;

                case "IloscOfert": 
                    kategorie = kategorie.OrderByDescending(s => s.LiczbaOfert);
                    break;
                case "IloscOfertAsc":
                    kategorie = kategorie.OrderBy(s => s.LiczbaOfert);
                    break;
            }
            return View(kategorie.ToPagedList<KategoriaViewModel>(currentPage, naStronie));
        }

        public ActionResult PokazOgloszenia(int id)
        {
            var ogloszenia = _repo.PobierzOgloszeniaZKategorii(id);
            OgloszeniaZKategoriiViewModels model = new OgloszeniaZKategoriiViewModels();
            model.Ogloszenia = ogloszenia.ToList();
            model.NazwaKategorii = _repo.NazwaDlaKategorii(id);
            return View(model);
        }

        [Route("JSON")]
        public ActionResult KategorieWJason()
        {
            var kategorie = _repo.PobierzKategorie().AsNoTracking();
            return Json(kategorie, JsonRequestBehavior.AllowGet);
        }
    }
}
