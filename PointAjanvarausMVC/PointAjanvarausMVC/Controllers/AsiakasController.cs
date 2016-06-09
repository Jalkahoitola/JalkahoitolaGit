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
    public class AsiakasController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Asiakas
        public ActionResult Index()
        {
            var asiakkaat = db.Asiakkaat.Include(a => a.Osoite).Include(a => a.Puhelin).Include(a => a.Huomiot1).Include(a => a.Hoitajat).Include(a => a.Varaus).Include(a => a.Palvelut);
            return View(asiakkaat.ToList());
        }

        //23.5.2016Lisätty tietokantataulujen suodatukset:
        public ActionResult OrderByFirstName()
        {
            var asiakkaat = from a in db.Asiakkaat
                            orderby a.Etunimi ascending
                            select a;
            return View(asiakkaat);
        }
        public ActionResult OrderByLastName()
        {
            var asiakkaat = from a in db.Asiakkaat
                            orderby a.Sukunimi ascending
                            select a;
            return View(asiakkaat);
        }//23.5.2016 Lisätty


        // GET: Asiakas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaat);
        }

        // GET: Asiakas/Create
        public ActionResult Create()
        {
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi");
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi");
            return View();
        }

        // POST: Asiakas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakas_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id,Hoitaja_ID,Varaus_ID,Palvelu_ID")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaat.Add(asiakkaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", asiakkaat.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", asiakkaat.Huomio_id);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", asiakkaat.Hoitaja_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", asiakkaat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", asiakkaat.Palvelu_ID);
            return View(asiakkaat);
        }

        // GET: Asiakas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", asiakkaat.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", asiakkaat.Huomio_id);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", asiakkaat.Hoitaja_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", asiakkaat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", asiakkaat.Palvelu_ID);
            return View(asiakkaat);
        }

        // POST: Asiakas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakas_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id,Hoitaja_ID,Varaus_ID,Palvelu_ID")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", asiakkaat.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", asiakkaat.Huomio_id);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", asiakkaat.Hoitaja_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Palvelun_nimi", asiakkaat.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", asiakkaat.Palvelu_ID);
            return View(asiakkaat);
        }

        // GET: Asiakas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaat);
        }

        // POST: Asiakas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            db.Asiakkaat.Remove(asiakkaat);
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
