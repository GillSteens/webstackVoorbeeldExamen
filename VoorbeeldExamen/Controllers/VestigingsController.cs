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
    public class VestigingsController : Controller
    {
        private VBEXDBContext db = new VBEXDBContext();

        // GET: Vestigings
        public ActionResult Index()
        {
            return View(db.Vestigings.ToList());
        }

        // GET: Vestigings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigings.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // GET: Vestigings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vestigings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam")] Vestiging vestiging)
        {
            if (ModelState.IsValid)
            {
                db.Vestigings.Add(vestiging);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vestiging);
        }

        // GET: Vestigings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigings.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // POST: Vestigings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam")] Vestiging vestiging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vestiging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vestiging);
        }

        // GET: Vestigings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigings.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // POST: Vestigings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vestiging vestiging = db.Vestigings.Find(id);
            db.Vestigings.Remove(vestiging);
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
