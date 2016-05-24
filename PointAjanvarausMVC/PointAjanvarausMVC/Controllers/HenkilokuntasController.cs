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
    public class HenkilokuntasController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Henkilokuntas
        public ActionResult Index()
        {
            var henkilokunta = db.Henkilokunta.Include(h => h.Osoite).Include(h => h.Puhelin).Include(h => h.Huomiot1);
            return View(henkilokunta.ToList());
        }

        // GET: Henkilokuntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Create
        public ActionResult Create()
        {
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut");
            return View();
        }

        // POST: Henkilokuntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Henkilokunta_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Sahkoposti,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Henkilokunta henkilokunta)
        {
            if (ModelState.IsValid)
            {
                db.Henkilokunta.Add(henkilokunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", henkilokunta.Huomio_id);
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", henkilokunta.Huomio_id);
            return View(henkilokunta);
        }

        // POST: Henkilokuntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Henkilokunta_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Sahkoposti,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Henkilokunta henkilokunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(henkilokunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", henkilokunta.Huomio_id);
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            return View(henkilokunta);
        }

        // POST: Henkilokuntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            db.Henkilokunta.Remove(henkilokunta);
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
