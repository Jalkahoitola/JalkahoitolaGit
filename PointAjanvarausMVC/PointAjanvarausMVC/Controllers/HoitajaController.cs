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
    public class HoitajaController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Hoitaja
        public ActionResult Index()
        {
            var hoitajat = db.Hoitajat.Include(h => h.Osoite).Include(h => h.Puhelin).Include(h => h.Huomiot);
            return View(hoitajat.ToList());
        }
        //Päivitetty 23.5.2016 tietokannan suodatustoimintoja
        public ActionResult OrderByFirstName()
        {
            var hoitajat = from h in db.Hoitajat
                           orderby h.Etunimi ascending
                           select h;
            return View(hoitajat);
        }
        public ActionResult OrderByLastName()
        {
            var hoitajat = from a in db.Hoitajat
                           orderby a.Sukunimi ascending
                           select a;
            return View(hoitajat);
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
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut");
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus");
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi");
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi");
            return View();
        }

        // POST: Hoitaja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hoitaja_ID,Tunnus,Etunimi,Toinen_nimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Aloituspvm,Valmistumispvm,Keskeytyspvm,Tiedot_arkistoitu,Huomio_ID,Osoite_ID,Puhelin_ID,Kurssi_ID,Sahkoposti")] Hoitajat hoitajat)
        {
            if (ModelState.IsValid)
            {
                db.Hoitajat.Add(hoitajat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", hoitajat.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", hoitajat.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", hoitajat.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", hoitajat.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", hoitajat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", hoitajat.Palvelu_ID);
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
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", hoitajat.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", hoitajat.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", hoitajat.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", hoitajat.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", hoitajat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", hoitajat.Palvelu_ID);
            return View(hoitajat);
        }

        // POST: Hoitaja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hoitaja_ID,Tunnus,Etunimi,Toinen_nimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Aloituspvm,Valmistumispvm,Keskeytyspvm,Tiedot_arkistoitu,Huomio_ID,Osoite_ID,Puhelin_ID,Kurssi_ID,Sahkoposti")] Hoitajat hoitajat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoitajat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", hoitajat.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", hoitajat.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", hoitajat.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", hoitajat.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", hoitajat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", hoitajat.Palvelu_ID);
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
