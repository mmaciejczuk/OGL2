using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OGL2.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Firma()
        {
            return View();
        }

        // GET: About
        public ActionResult Instrukcja()
        {
            return View();
        }

        // GET: About
        public ActionResult Kursy()
        {
            return View();
        }
    }
}