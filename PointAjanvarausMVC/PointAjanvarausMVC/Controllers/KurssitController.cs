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
    public class KurssitController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Kurssit
        public ActionResult Index()
        {
            var kurssi = db.Kurssi.Include(k => k.Hoitajat).Include(k => k.Rekisterointi1);
            return View(kurssi.ToList());
        }

        //1.6.2016Lisätty tietokantataulujen suodatukset:
        public ActionResult OrderByEtunimi()
        {
            var kurssi = from k in db.Kurssi
                            orderby k.Etunimi ascending
                            select k;
            return View(kurssi);
        }
        public ActionResult OrderByLastName()
        {
            var kurssi = from k in db.Kurssi
                            orderby k.Sukunimi ascending
                            select k;
            return View(kurssi);
        }//1.6.2016 Lisätty

        // GET: Kurssit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            return View(kurssi);
        }

        // GET: Kurssit/Create
        public ActionResult Create()
        {
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Rekisterointi_ID = new SelectList(db.Rekisterointi, "Rekisterointi_ID", "Vuosikurssi");
            return View();
        }

        // POST: Kurssit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kurssi_ID,Etunimi,Sukunimi,Kurssinimike,Opintopisteet,Kurssin_aloitus_pvm,Kurssin_lopetus_pvm,Rekisterointi_ID,Hoitaja_ID")] Kurssi kurssi)
        {
            if (ModelState.IsValid)
            {
                db.Kurssi.Add(kurssi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", kurssi.Hoitaja_ID);
            ViewBag.Rekisterointi_ID = new SelectList(db.Rekisterointi, "Rekisterointi_ID", "Vuosikurssi", kurssi.Rekisterointi_ID);
            return View(kurssi);
        }

        // GET: Kurssit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", kurssi.Hoitaja_ID);
            ViewBag.Rekisterointi_ID = new SelectList(db.Rekisterointi, "Rekisterointi_ID", "Vuosikurssi", kurssi.Rekisterointi_ID);
            return View(kurssi);
        }

        // POST: Kurssit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kurssi_ID,Etunimi,Sukunimi,Kurssinimike,Opintopisteet,Kurssin_aloitus_pvm,Kurssin_lopetus_pvm,Rekisterointi_ID,Hoitaja_ID")] Kurssi kurssi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurssi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", kurssi.Hoitaja_ID);
            ViewBag.Rekisterointi_ID = new SelectList(db.Rekisterointi, "Rekisterointi_ID", "Vuosikurssi", kurssi.Rekisterointi_ID);
            return View(kurssi);
        }

        // GET: Kurssit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            return View(kurssi);
        }

        // POST: Kurssit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurssi kurssi = db.Kurssi.Find(id);
            db.Kurssi.Remove(kurssi);
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
