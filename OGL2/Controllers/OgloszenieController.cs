using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using System.Diagnostics;

namespace OGL2.Controllers
{
    public class OgloszenieController : Controller
    {
        private OglContext db = new OglContext();

        // GET: Ogloszenies
        public ActionResult Index()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            var ogloszenia = db.Ogloszenia.AsNoTracking();
            return View(ogloszenia.ToList());
        }

        // GET: Ogloszenies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenia.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Create
        public ActionResult Create()
        {
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Ogloszenies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tresc,Tytul,DataDodania,UzytkownikId")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                db.Ogloszenia.Add(ogloszenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ogloszenie.UzytkownikId);
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenia.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ogloszenie.UzytkownikId);
            return View(ogloszenie);
        }

        // POST: Ogloszenies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tresc,Tytul,DataDodania,UzytkownikId")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogloszenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ogloszenie.UzytkownikId);
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenia.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        // POST: Ogloszenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogloszenie ogloszenie = db.Ogloszenia.Find(id);
            db.Ogloszenia.Remove(ogloszenie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
