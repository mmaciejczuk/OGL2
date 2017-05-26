using Repozytorium.IRepo;
using Repozytorium.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace OGL2.Controllers
{
    public class CVController : Controller
    {
        private readonly ICVRepo _repo;
        public CVController(ICVRepo repo)
        {
            _repo = repo;
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
            var ogloszenia = _repo.PobierzCV();

            switch (sortOrder)
            {
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

        [OutputCache(Duration = 1000)]
        public ActionResult MojeCV(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            string userId = User.Identity.GetUserId();
            var ogloszenia = _repo.PobierzCV();
            ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania).Where(o => o.UzytkownikId == userId);
            return View(ogloszenia.ToPagedList<CVViewModel>(currentPage, naStronie));
        }

        // GET: CV
        public ActionResult StworzCV()
        {
            return View();
        }
    }
}