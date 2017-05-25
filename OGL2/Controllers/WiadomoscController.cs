using Microsoft.AspNet.Identity;
using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OGL2.Controllers
{
    public class WiadomoscController : Controller
    {
        private readonly IWiadomoscRepo _repo;
        public WiadomoscController(IWiadomoscRepo repo)
        {
            _repo = repo;
        }

        // GET: Wiadomosc
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Wyslano(string userId, int ofertaId)
        {    
            string authId = User.Identity.GetUserId();
            Wiadomosc wiadomosc = new Wiadomosc();
            _repo.WyslijWiadomosc(wiadomosc);
            return View();
        }
    }
}