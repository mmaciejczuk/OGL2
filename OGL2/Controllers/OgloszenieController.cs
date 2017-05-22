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

        public OgloszenieController()
        {

        }

        public OgloszenieController(IOgloszenieRepo repo)
        {
            _repo = repo;
        }

//-------------------------- INDEX----------------------------------------
        public ActionResult Index(int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int naStronie = 6;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSort = String.IsNullOrEmpty(sortOrder) ? "IdAsc" : "";
            ViewBag.DataDodaniaSort = sortOrder == "DataDodania" ? "DataDodaniaAsc" : "DataDodania";
            ViewBag.TrescSort = sortOrder == "TrescAsc" ? "Tresc" : "TrescAsc";
            ViewBag.TytulSort = sortOrder == "TytulAsc" ? "Tytul" : "TytulAsc";
            var ogloszenia = _repo.PobierzOgloszenia();

            switch (sortOrder)
            {
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
                case "Tresc":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Tytul);
                    break;
                case "TrescAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Tytul);
                    break;
                case "IdAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Tytul);
                    break;
                default:  // id descending
                    ogloszenia = ogloszenia.OrderByDescending(s => s.DataDodania);
                    break;
            }
            ogloszenia = ogloszenia.OrderBy(d => d.DataDodania);
            return View(ogloszenia.ToPagedList<OgloszeniaViewModel>(currentPage, naStronie));
        }

// ------------------------- DETAILS -------------------------------------
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = _repo.GetOgloszeniaById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

// ------------------------- CREATE -------------------------------------
        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tresc,Tytul")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                // using Microsoft.AspNet.Identity;
                ogloszenie.UzytkownikId = User.Identity.GetUserId();
                ogloszenie.DataDodania = DateTime.Now;
                try
                {
                    _repo.Dodaj(ogloszenie);
                    _repo.SaveChages();
                    return RedirectToAction("MojeOgloszenia");
                }
                catch (Exception)
                {
                    return View(ogloszenie);
                }
            }
            return View(ogloszenie);
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
            Ogloszenie ogloszenie = _repo.GetOgloszeniaById((int)id);
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
        public ActionResult Edit([Bind(Include = "Id,Tresc,Tytul,DataDodania,UzytkownikId")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // ogloszenie.UzytkownikId = "ffgfs";
                    _repo.Aktualizuj(ogloszenie);
                    _repo.SaveChages();
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

// ------------------------- DELETE -------------------------------------

        // GET
        [Authorize]
        public ActionResult Delete(int? id, bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = _repo.GetOgloszeniaById((int)id);
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
                _repo.SaveChages();
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

        [OutputCache(Duration = 1000)]
        public ActionResult MojeOgloszenia(int? page)
        {
            //int currentPage = page ?? 1;
            //int naStronie = 3;
            //string userId = User.Identity.GetUserId();
            //var ogloszenia = _repo.PobierzOgloszenia();
            //ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania).Where(o => o.UzytkownikId == userId);
            //return View(ogloszenia.ToPagedList<Ogloszenie>(currentPage, naStronie));
            return null;
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
