using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OGL2.Controllers
{
    public class UzytkownikController : Controller
    {
        // GET: Uzytkownik
        public ActionResult Index()
        {
            return View();
        }

        // GET: Uzytkownik/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Uzytkownik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uzytkownik/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Uzytkownik/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uzytkownik/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
