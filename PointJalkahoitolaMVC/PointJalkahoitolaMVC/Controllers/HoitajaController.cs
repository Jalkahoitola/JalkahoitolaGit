using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointJalkahoitolaMVC.Database1;

namespace PointJalkahoitolaMVC.Controllers
{
    public class HoitajaController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Hoitaja
        public ActionResult Index()
        {
            return View(db.Hoitajat.ToList());
        }

        // GET: Hoitaja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitajat hoitajat = db.Hoitajat.Find(id);
            if (hoitajat == null)
            {
                return HttpNotFound();
            }
            return View(hoitajat);
        }

        // GET: Hoitaja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hoitaja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoitajaID,Etunimi,Sukunimi,Osoite")] Hoitajat hoitajat)
        {
            if (ModelState.IsValid)
            {
                db.Hoitajat.Add(hoitajat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoitajat);
        }

        // GET: Hoitaja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitajat hoitajat = db.Hoitajat.Find(id);
            if (hoitajat == null)
            {
                return HttpNotFound();
            }
            return View(hoitajat);
        }

        // POST: Hoitaja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoitajaID,Etunimi,Sukunimi,Osoite")] Hoitajat hoitajat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoitajat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoitajat);
        }

        // GET: Hoitaja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitajat hoitajat = db.Hoitajat.Find(id);
            if (hoitajat == null)
            {
                return HttpNotFound();
            }
            return View(hoitajat);
        }

        // POST: Hoitaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoitajat hoitajat = db.Hoitajat.Find(id);
            db.Hoitajat.Remove(hoitajat);
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
