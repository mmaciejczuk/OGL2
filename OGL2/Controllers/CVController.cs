using Repozytorium.IRepo;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;
using System.Net;

namespace OGL2.Controllers
{
    public class CVController : Controller
    {
        private readonly ICVRepo _repo;
        private readonly IKategoriaRepo _kategoriaRepo;
        private readonly IMiastoRepo _miastoRepo;
        private readonly IWiadomoscRepo _messageRepo;

        public CVController(ICVRepo repo, IMiastoRepo miastoRepo, IKategoriaRepo kategoriaRepo,
            IWiadomoscRepo messageRepo)
        {
            _repo = repo;
            _kategoriaRepo = kategoriaRepo;
            _miastoRepo = miastoRepo;
            _messageRepo = messageRepo;
        }

        public ActionResult Index(int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int naStronie = 6;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DataDodaniaSort = sortOrder == "DataDodania" ? "DataDodaniaAsc" : "DataDodania";
            ViewBag.TrescSort = sortOrder == "TrescAsc" ? "Tresc" : "TrescAsc";
            ViewBag.TytulSort = sortOrder == "TytulAsc" ? "Tytul" : "TytulAsc";
            ViewBag.MiastoSort = sortOrder == "MiastoAsc" ? "Miasto" : "MiastoAsc";
            ViewBag.NazwaSort = sortOrder == "NazwaAsc" ? "Nazwa" : "NazwaAsc";
            ViewBag.IdSort = sortOrder == "IdAsc" ? "Id" : "IdAsc";
            var ogloszenia = _repo.PobierzCV();

            switch (sortOrder)
            {
                case "Id":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.IdCV);
                    break;
                case "IdAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.IdCV);
                    break;

                case "Nazwa":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Nazwisko);
                    break;
                case "NazwaAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Nazwisko);
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

                case "Tresc":
                    ogloszenia = ogloszenia.OrderByDescending(s => s.Tresc);
                    break;
                case "TrescAsc":
                    ogloszenia = ogloszenia.OrderBy(s => s.Tresc);
                    break;

                default:  // id descending
                    ogloszenia = ogloszenia.OrderByDescending(s => s.DataDodania);
                    break;
            }
            return View(ogloszenia.ToPagedList<CVViewModel>(currentPage, naStronie));
        }

        //[OutputCache(Duration = 1000)]
        public ActionResult MojeCV()
        { 
            string userId = User.Identity.GetUserId();
            int cvId = _repo.GetCVByGuid(userId);
            var ogloszenia = _repo.GetCVById(cvId);
            return View(ogloszenia);
        }

        // ------------------------- CREATE -------------------------------------
        // GET
        public ActionResult Create()
        {
            CVEditViewModel cvModel = new CVEditViewModel();
            cvModel.Miasta = _miastoRepo.GetCities();
            cvModel.Kategorie = _kategoriaRepo.GetCategories();
            //cvModel.Doswiadczenie = _repo.GetExperience();
            if (cvModel == null)
            {
                return HttpNotFound();
            }
            else if (cvModel.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(cvModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CVEditViewModel cvViewModel, FormCollection formCollection)
        {
            cvViewModel.Miasta = _miastoRepo.GetCities();
            cvViewModel.Kategorie = _kategoriaRepo.GetCategories();

            var a = Convert.ToInt32(formCollection["kategoriaSelect"]);
            var b = Convert.ToInt32(formCollection["miastoSelect"]);

            if (ModelState.IsValid && Convert.ToInt32(formCollection["kategoriaSelect"]) != 0
                                    && Convert.ToInt32(formCollection["miastoSelect"]) != 0)
            {
                cvViewModel.KategoriaId = Convert.ToInt32(formCollection["kategoriaSelect"]);
                cvViewModel.MiastoId = Convert.ToInt32(formCollection["miastoSelect"]);
                cvViewModel.UzytkownikId = User.Identity.GetUserId();
                cvViewModel.DataDodania = DateTime.Now;
                try
                {
                    //_repo.Dodaj(cvViewModel);
                    _repo.SaveChanges();
                    return RedirectToAction("MojeCV");
                }
                catch (Exception)
                {
                    ViewBag.Blad = true;
                    return View(cvViewModel);
                }
            }
            ViewBag.Blad = true;
            return View(cvViewModel);
        }
    }
}