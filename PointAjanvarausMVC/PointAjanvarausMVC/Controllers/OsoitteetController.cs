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
    public class OsoitteetController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Osoitteet
        public ActionResult Index()
        {
            var osoite = db.Osoite.Include(o => o.Asiakkaat1).Include(o => o.Henkilokunta1).Include(o => o.Hoitajat1).Include(o => o.Toimipisteet).Include(o => o.Shippers);
            return View(osoite.ToList());
        }

        // GET: Osoitteet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // GET: Osoitteet/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus");
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Tunnus");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi");
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi");
            return View();
        }

        // POST: Osoitteet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Osoite_ID,Katuosoite,Postinumero,Postitoimipaikka,Asiakas_ID,Hoitaja_ID,Henkilokunta_ID,Toimipiste_ID,Shipper_ID")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Osoite.Add(osoite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", osoite.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", osoite.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", osoite.Hoitaja_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", osoite.Toimipiste_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", osoite.Shipper_ID);
            return View(osoite);
        }

        // GET: Osoitteet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", osoite.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", osoite.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", osoite.Hoitaja_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", osoite.Toimipiste_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", osoite.Shipper_ID);
            return View(osoite);
        }

        // POST: Osoitteet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Osoite_ID,Katuosoite,Postinumero,Postitoimipaikka,Asiakas_ID,Hoitaja_ID,Henkilokunta_ID,Toimipiste_ID,Shipper_ID")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", osoite.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", osoite.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", osoite.Hoitaja_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", osoite.Toimipiste_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", osoite.Shipper_ID);
            return View(osoite);
        }

        // GET: Osoitteet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // POST: Osoitteet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoite osoite = db.Osoite.Find(id);
            db.Osoite.Remove(osoite);
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
