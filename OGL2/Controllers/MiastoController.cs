using PagedList;
using Repozytorium.IRepo;
using Repozytorium.Models;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OGL2.Controllers
{
    public class MiastoController : Controller
    {
        private readonly IMiastoRepo _repo;
        private readonly IOgloszenieRepo _oglRepo;
        public MiastoController(IMiastoRepo repo, IOgloszenieRepo oglRepo)
        {
            _repo = repo;
            _oglRepo = oglRepo;
        }

        // GET
        public ActionResult Dodaj()
        {
            return View();
        }

        // POST
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dodaj(Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Dodaj(miasto);
                    _repo.SaveChanges();
                    return RedirectToAction("Sukces");
                }
                catch (Exception)
                {
                    return View(miasto);
                }
            }
            return View(miasto);
        }

        public ActionResult Sukces()
        {
            return View();
        }

        // GET: Miasto
        public ActionResult Index(int? page, string sortOrder)
        {
        int currentPage = page ?? 1;
            int naStronie = 10;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazwaSort = sortOrder == "NazwaAsc" ? "Nazwa" : "NazwaAsc";
            ViewBag.IloscOfertSort = sortOrder == "IloscOfertAsc" ? "IloscOfert" : "IloscOfertAsc";

            var kategorie = _repo.PobierzMiasta();

            switch (sortOrder)
            {
                case "Nazwa":
                    kategorie = kategorie.OrderByDescending(s => s.Nazwa);
                    break;
                case "NazwaAsc":
                    kategorie = kategorie.OrderBy(s => s.Nazwa);
                    break;

                case "IloscOfert":
                    kategorie = kategorie.OrderByDescending(s => s.LiczbaOfert);
                    break;
                case "IloscOfertAsc":
                    kategorie = kategorie.OrderBy(s => s.LiczbaOfert);
                    break;
            }
            return View(kategorie.ToPagedList<MiastoViewModel>(currentPage, naStronie));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgloszenieDetailsViewModel ogloszenie = _oglRepo.GetOgloszeniaById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        public ActionResult PokazOgloszenia(int id, int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int naStronie = 12;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdOgloszenia = sortOrder == "IdOgloszenia" ? "IdOgloszeniaAsc" : "IdOgloszenia";
            ViewBag.DataDodaniaSort = sortOrder == "DataDodania" ? "DataDodaniaAsc" : "DataDodania";
            ViewBag.TytulSort = sortOrder == "TytulAsc" ? "Tytul" : "TytulAsc";
            ViewBag.MiastoSort = sortOrder == "MiastoAsc" ? "Miasto" : "MiastoAsc";
            ViewBag.RodzajUmowySort = sortOrder == "RodzajUmowyAsc" ? "RodzajUmowy" : "RodzajUmowyAsc";
            var ogloszenia = _repo.PobierzOgloszeniaZMiasta(id);
            switch (sortOrder)
            {
                case "IdOgloszenia":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.IdOgloszenia);
                    break;
                case "IdOgloszeniaAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.IdOgloszenia);
                    break;

                case "RodzajUmowy":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.RodzajUmowy);
                    break;
                case "RodzajUmowyAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.RodzajUmowy);
                    break;

                case "Miasto":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Miasto);
                    break;
                case "MiastoAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Miasto);
                    break;

                case "DataDodania":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.DataDodania);
                    break;
                case "DataDodaniaAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.DataDodania);
                    break;

                case "Tytul":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Tytul);
                    break;
                case "TytulAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Tytul);
                    break;

                default:  // id descending
                    ogloszenia = ogloszenia.OrderByDescending(s => s.DataDodania);
                    break;
            }
            return View(ogloszenia.ToPagedList<OgloszeniaZMiastaViewModel>(currentPage, naStronie));
        }

        // GET
        [Authorize]
        public ActionResult Delete(int? id, bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miasto miasto = _repo.GetMiastoById((int)id);
            if (miasto == null)
            {
                return HttpNotFound();
            }
            else if (!User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (blad != null)
                ViewBag.Blad = true;
            return View(miasto);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.UsunMiasto(id);
            try
            {
                _repo.SaveChanges();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Delete", new { id = id, blad = true });
            }
            return RedirectToAction("Index");
        }

        // ------------------------- EDIT -------------------------------------
        // GET
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miasto miasto = _repo.GetMiastoById((int)id);

            if (miasto == null)
            {
                return HttpNotFound();
            }
            else if (!(User.IsInRole("Admin")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(miasto);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // ogloszenie.UzytkownikId = "ffgfs";
                    _repo.Aktualizuj(miasto);
                    _repo.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.Blad = true;
                    return View(miasto);
                }
            }
            ViewBag.Blad = false;
            return View(miasto);
        }

    }
}