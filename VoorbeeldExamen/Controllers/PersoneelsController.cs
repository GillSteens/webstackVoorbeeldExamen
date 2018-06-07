using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoorbeeldExamen.Models;

namespace VoorbeeldExamen.Controllers
{
    public class PersoneelsController : Controller
    {
        private VBEXDBContext db = new VBEXDBContext();

        // GET: Personeels
        public ActionResult Index()
        {
            var personeels = db.Personeels.Include(p => p.Vestiging);
            return View(personeels.ToList());
        }

        // GET: Personeels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeel personeel = db.Personeels.Find(id);
            if (personeel == null)
            {
                return HttpNotFound();
            }
            return View(personeel);
        }

        // GET: Personeels/Create
        public ActionResult Create()
        {
            ViewBag.IdVestiging = new SelectList(db.Vestigings, "Id", "Naam");
            return View();
        }

        // POST: Personeels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Voornaam,Achternaam,Wachtwoord,IdVestiging")] Personeel personeel)
        {
            if (ModelState.IsValid)
            {
                db.Personeels.Add(personeel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdVestiging = new SelectList(db.Vestigings, "Id", "Naam", personeel.IdVestiging);
            return View(personeel);
        }

        // GET: Personeels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeel personeel = db.Personeels.Find(id);
            if (personeel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdVestiging = new SelectList(db.Vestigings, "Id", "Naam", personeel.IdVestiging);
            return View(personeel);
        }

        // POST: Personeels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Voornaam,Achternaam,Wachtwoord,IdVestiging")] Personeel personeel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personeel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdVestiging = new SelectList(db.Vestigings, "Id", "Naam", personeel.IdVestiging);
            return View(personeel);
        }

        // GET: Personeels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeel personeel = db.Personeels.Find(id);
            if (personeel == null)
            {
                return HttpNotFound();
            }
            return View(personeel);
        }

        // POST: Personeels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personeel personeel = db.Personeels.Find(id);
            db.Personeels.Remove(personeel);
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
