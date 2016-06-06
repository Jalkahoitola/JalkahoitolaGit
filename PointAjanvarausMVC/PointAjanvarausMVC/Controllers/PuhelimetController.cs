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
    public class PuhelimetController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Puhelimet
        public ActionResult Index()
        {
            var puhelin = db.Puhelin.Include(p => p.Asiakkaat1).Include(p => p.Henkilokunta1).Include(p => p.Hoitajat1).Include(p => p.Shippers);
            return View(puhelin.ToList());
        }

        // GET: Puhelimet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            return View(puhelin);
        }

        // GET: Puhelimet/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi");
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi");
            return View();
        }

        // POST: Puhelimet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Puhelin_ID,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3,Asiakas_ID,Hoitaja_ID,Henkilokunta_ID,Shipper_ID")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Puhelin.Add(puhelin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", puhelin.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", puhelin.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", puhelin.Hoitaja_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", puhelin.Shipper_ID);
            return View(puhelin);
        }

        // GET: Puhelimet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", puhelin.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", puhelin.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", puhelin.Hoitaja_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", puhelin.Shipper_ID);
            return View(puhelin);
        }

        // POST: Puhelimet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Puhelin_ID,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3,Asiakas_ID,Hoitaja_ID,Henkilokunta_ID,Shipper_ID")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puhelin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", puhelin.Asiakas_ID);
            ViewBag.Henkilokunta_ID = new SelectList(db.Henkilokunta, "Henkilokunta_ID", "Etunimi", puhelin.Henkilokunta_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", puhelin.Hoitaja_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_ID", "Yritysnimi", puhelin.Shipper_ID);
            return View(puhelin);
        }

        // GET: Puhelimet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            return View(puhelin);
        }

        // POST: Puhelimet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puhelin puhelin = db.Puhelin.Find(id);
            db.Puhelin.Remove(puhelin);
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
