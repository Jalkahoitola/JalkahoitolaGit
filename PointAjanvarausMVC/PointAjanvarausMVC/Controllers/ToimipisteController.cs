using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointAjanvarausMVC.Models;

namespace PointAjanvarausMVC.Controllers
{
    public class ToimipisteController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Toimipiste
        public ActionResult Index()
        {
            var toimipisteet = db.Toimipisteet.Include(t => t.Hoitopaikat1).Include(t => t.Huomiot).Include(t => t.Osoite).Include(t => t.Puhelin);
            return View(toimipisteet.ToList());
        }

        // GET: Toimipiste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            return View(toimipisteet);
        }

        // GET: Toimipiste/Create
        public ActionResult Create()
        {
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi");
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Sairaudet");
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            return View();
        }

        // POST: Toimipiste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Toimipiste_ID,Toimipisteen_Nimi,Hoitopaikka_ID,Osoite_ID,Puhelin_ID,Huomio_ID")] Toimipisteet toimipisteet)
        {
            if (ModelState.IsValid)
            {
                db.Toimipisteet.Add(toimipisteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", toimipisteet.Hoitopaikka_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Sairaudet", toimipisteet.Huomio_ID);
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", toimipisteet.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", toimipisteet.Puhelin_ID);
            return View(toimipisteet);
        }

        // GET: Toimipiste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", toimipisteet.Hoitopaikka_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Sairaudet", toimipisteet.Huomio_ID);
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", toimipisteet.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", toimipisteet.Puhelin_ID);
            return View(toimipisteet);
        }

        // POST: Toimipiste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Toimipiste_ID,Toimipisteen_Nimi,Hoitopaikka_ID,Osoite_ID,Puhelin_ID,Huomio_ID")] Toimipisteet toimipisteet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toimipisteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", toimipisteet.Hoitopaikka_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Sairaudet", toimipisteet.Huomio_ID);
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", toimipisteet.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", toimipisteet.Puhelin_ID);
            return View(toimipisteet);
        }

        // GET: Toimipiste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            return View(toimipisteet);
        }

        // POST: Toimipiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            db.Toimipisteet.Remove(toimipisteet);
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
