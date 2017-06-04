using System.Net;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.IRepo;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using PagedList;
using Repozytorium.Models.Views;

namespace OGL2.Controllers
{
    public class OgloszenieController : Controller
    {
        private readonly IOgloszenieRepo _repo;
        private readonly IWiadomoscRepo _messageRepo;
        public OgloszenieController()
        {

        }

        public OgloszenieController(IOgloszenieRepo repo, IWiadomoscRepo messageRepo)
        {
            _repo = repo;
            _messageRepo = messageRepo;
        }

//-------------------------- INDEX----------------------------------------
        public ActionResult Index(int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int naStronie = 6;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdOgloszenia = sortOrder == "IdOgloszenia" ? "IdOgloszeniaAsc" : "IdOgloszenia";
            ViewBag.DataDodaniaSort = sortOrder == "DataDodania" ? "DataDodaniaAsc" : "DataDodania";
            ViewBag.TytulSort = sortOrder == "TytulAsc" ? "Tytul" : "TytulAsc";
            ViewBag.MiastoSort = sortOrder == "MiastoAsc" ? "Miasto" : "MiastoAsc";
            ViewBag.RodzajUmowySort = sortOrder == "RodzajUmowyAsc" ? "RodzajUmowy" : "RodzajUmowyAsc";
            ViewBag.ZaakceptowaneSort = sortOrder == "ZaakceptowaneAsc" ? "Zaakceptowane" : "ZaakceptowaneAsc";
            var ogloszenia = _repo.PobierzOgloszenia();

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

                case "Zaakceptowane":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Zaakceptowane);
                    break;
                case "ZaakceptowaneAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Zaakceptowane);
                    break;

                default:  // id descending
                    ogloszenia = ogloszenia.OrderByDescending(s => s.DataDodania);
                    break;
            }
            return View(ogloszenia.ToPagedList<OgloszenieViewModel>(currentPage, naStronie));
        }

// ------------------------- DETAILS -------------------------------------
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgloszenieDetailsViewModel ogloszenie = _repo.GetOgloszeniaById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(string UzytkownikId, int IdOgloszenia, string tresc)
        {
            OgloszenieDetailsViewModel ogloszenie = _repo.GetOgloszeniaById((int)IdOgloszenia);
            if (ModelState.IsValid)
            {
                try
                {
                    //tutaj zapis do bazy
                    _messageRepo.SendMessage(UzytkownikId, IdOgloszenia, tresc);
                    _messageRepo.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.Blad = true;
                    return View(ogloszenie);
                }
            }
            
            ViewBag.Blad = false;
            return View(ogloszenie);
        }

        // ------------------------- CREATE -------------------------------------
        // GET
        public ActionResult Create()
        {
            OgloszenieEditViewModel ogloszenie = new OgloszenieEditViewModel();
            ogloszenie.Miasta = _repo.GetCities();
            ogloszenie.RodzajeUmowy = _repo.GetAgreementTypes();
            ogloszenie.Kategorie = _repo.GetCategories();
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            else if (ogloszenie.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(ogloszenie);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(OgloszenieEditViewModel ogloszenieEditViewModel, FormCollection formCollection)
        {
            ogloszenieEditViewModel.Miasta = _repo.GetCities();
            ogloszenieEditViewModel.RodzajeUmowy = _repo.GetAgreementTypes();
            ogloszenieEditViewModel.Kategorie = _repo.GetCategories();

            var a = Convert.ToInt32(formCollection["kategoriaSelect"]);
            var b = Convert.ToInt32(formCollection["miastoSelect"]);
            var c = Convert.ToInt32(formCollection["rodzajUmowySelect"]);

            if (ModelState.IsValid && Convert.ToInt32(formCollection["kategoriaSelect"]) != 0
                                    && Convert.ToInt32(formCollection["miastoSelect"]) != 0
                                    && Convert.ToInt32(formCollection["rodzajUmowySelect"]) != 0)
            {
                ogloszenieEditViewModel.KategoriaId = Convert.ToInt32(formCollection["kategoriaSelect"]);
                ogloszenieEditViewModel.MiastoId = Convert.ToInt32(formCollection["miastoSelect"]);
                ogloszenieEditViewModel.RodzajUmowyId = Convert.ToInt32(formCollection["rodzajUmowySelect"]);
                ogloszenieEditViewModel.UzytkownikId = User.Identity.GetUserId();
                ogloszenieEditViewModel.DataDodania = DateTime.Now;
                try
                {
                    _repo.Dodaj(ogloszenieEditViewModel);
                    _repo.SaveChanges();
                    _repo.InsertOgloszenieKategoria(ogloszenieEditViewModel.KategoriaId);
                    _repo.SaveChanges();
                    return RedirectToAction("MojeOgloszenia");
                }
                catch (Exception)
                {
                    ViewBag.Blad = true;
                    return View(ogloszenieEditViewModel);
                }
            }
            ViewBag.Blad = true;
            return View(ogloszenieEditViewModel);
        }

// ------------------------- EDIT -------------------------------------
        // GET
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgloszenieEditViewModel ogloszenie = _repo.GetOgloszenieDetailsById((int)id);
            ogloszenie.Miasta = _repo.GetCities();
            ogloszenie.RodzajeUmowy = _repo.GetAgreementTypes();
            ogloszenie.Kategorie = _repo.GetCategories();
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            else if (ogloszenie.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(ogloszenie);
        }

        
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(OgloszenieEditViewModel ogloszenieEditViewModel, FormCollection formCollection)
        {
            ogloszenieEditViewModel.KategoriaId = Convert.ToInt32(formCollection["kategoriaSelect"]);
            ogloszenieEditViewModel.MiastoId = Convert.ToInt32(formCollection["miastoSelect"]);
            ogloszenieEditViewModel.RodzajUmowyId = Convert.ToInt32(formCollection["rodzajUmowySelect"]);
            ogloszenieEditViewModel.Miasta = _repo.GetCities();
            ogloszenieEditViewModel.RodzajeUmowy = _repo.GetAgreementTypes();
            ogloszenieEditViewModel.Kategorie = _repo.GetCategories();

            if (ModelState.IsValid)
            {                
                try
                {
                    _repo.Aktualizuj(ogloszenieEditViewModel);
                    _repo.SaveChanges();
                }
                catch (Exception)
                { 
                    ViewBag.Blad = true;
                    return View(ogloszenieEditViewModel);
                }
            }
            ViewBag.Blad = false;
            return View(ogloszenieEditViewModel);
        }

// ------------------------- DELETE -------------------------------------

        // GET
        [Authorize]
        public ActionResult Delete(int? id, bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgloszenieDetailsViewModel ogloszenie = _repo.GetOgloszeniaById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            else if (ogloszenie.UzytkownikId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (blad != null)
                ViewBag.Blad = true;
            return View(ogloszenie);

        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.UsunOgloszenie(id);
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


// ------------------------- PARTIAL -------------------------------------
        public ActionResult Partial(int? page)
        {
            //int currentPage = page ?? 1;
            //int naStronie = 3;
            //var ogloszenia = _repo.PobierzOgloszenia();
            //ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania);
            //return PartialView("Index", ogloszenia.ToPagedList<Ogloszenie>(currentPage, naStronie));
            return null;
        }

        //[OutputCache(Duration = 1000)]
        public ActionResult MojeOgloszenia(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            string userId = User.Identity.GetUserId();
            var ogloszenia = _repo.PobierzOgloszenia();
            ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania).Where(o => o.UzytkownikId == userId);
            return View(ogloszenia.ToPagedList<OgloszenieViewModel>(currentPage, naStronie));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
