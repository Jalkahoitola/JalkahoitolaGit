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
            var asiakkaat = db.Asiakkaat.Include(a => a.Osoite).Include(a => a.Puhelin).Include(a => a.Huomiot1);
            return View(asiakkaat.ToList());
        }
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
        }
   

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
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "ID");
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "ID");
            return View();
        }

        // POST: Asiakas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakas_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaat.Add(asiakkaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", asiakkaat.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "ID", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "ID", asiakkaat.Huomio_id);
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
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "ID", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Sairaudet", asiakkaat.Huomio_id);
            return View(asiakkaat);
        }

        // POST: Asiakas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakas_ID,Etunimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", asiakkaat.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "ID", asiakkaat.Puhelin_id);
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "ID", asiakkaat.Huomio_id);
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
