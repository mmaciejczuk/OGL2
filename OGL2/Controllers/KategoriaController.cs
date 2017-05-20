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
        public ActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            var kategorie = _repo.PobierzKategorie().AsNoTracking();
            return View(kategorie.ToPagedList<Kategoria>(currentPage, naStronie));
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
