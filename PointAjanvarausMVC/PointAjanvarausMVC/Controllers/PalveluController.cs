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
    public class PalveluController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Palvelu
        public ActionResult Index()
        {
            var palvelut = db.Palvelut.Include(p => p.Asiakkaat).Include(p => p.Hoitajat).Include(p => p.Toimipisteet);
            return View(palvelut.ToList());
        }

        // GET: Palvelu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            return View(palvelut);
        }

        // GET: Palvelu/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Toimipiste_id = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi");
            return View();
        }

        // POST: Palvelu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Palvelu_ID,Palvelun_nimi,Palvelun_kesto,Asiakas_id,Hoitaja_id,Toimipiste_id")] Palvelut palvelut)
        {
            if (ModelState.IsValid)
            {
                db.Palvelut.Add(palvelut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", palvelut.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", palvelut.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", palvelut.Toimipiste_id);
            return View(palvelut);
        }

        // GET: Palvelu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", palvelut.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", palvelut.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", palvelut.Toimipiste_id);
            return View(palvelut);
        }

        // POST: Palvelu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Palvelu_ID,Palvelun_nimi,Palvelun_kesto,Asiakas_id,Hoitaja_id,Toimipiste_id")] Palvelut palvelut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palvelut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", palvelut.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", palvelut.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", palvelut.Toimipiste_id);
            return View(palvelut);
        }

        // GET: Palvelu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            return View(palvelut);
        }

        // POST: Palvelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palvelut palvelut = db.Palvelut.Find(id);
            db.Palvelut.Remove(palvelut);
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
