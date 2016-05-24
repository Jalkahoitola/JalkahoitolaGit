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
    public class TilausController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Tilaus
        public ActionResult Index()
        {
            var tilaukset = db.Tilaukset.Include(t => t.Tuotteet);
            return View(tilaukset.ToList());
        }

        // GET: Tilaus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            return View(tilaukset);
        }

        // GET: Tilaus/Create
        public ActionResult Create()
        {
            ViewBag.Tuote_ID = new SelectList(db.Tuotteet, "Tuote_ID", "Tuotenimi");
            return View();
        }

        // POST: Tilaus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tilaus_ID,Toimittaja_ID,Tuote_ID,Henkilokunta_ID,Tilausmäärä,Tilauspäivä,Toimitus_pvm,Saapumispvm,ShipName,ShipAddress,Shipper_ID")] Tilaukset tilaukset)
        {
            if (ModelState.IsValid)
            {
                db.Tilaukset.Add(tilaukset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tuote_ID = new SelectList(db.Tuotteet, "Tuote_ID", "Tuotenimi", tilaukset.Tuote_ID);
            return View(tilaukset);
        }

        // GET: Tilaus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tuote_ID = new SelectList(db.Tuotteet, "Tuote_ID", "Tuotenimi", tilaukset.Tuote_ID);
            return View(tilaukset);
        }

        // POST: Tilaus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tilaus_ID,Toimittaja_ID,Tuote_ID,Henkilokunta_ID,Tilausmäärä,Tilauspäivä,Toimitus_pvm,Saapumispvm,ShipName,ShipAddress,Shipper_ID")] Tilaukset tilaukset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tilaukset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tuote_ID = new SelectList(db.Tuotteet, "Tuote_ID", "Tuotenimi", tilaukset.Tuote_ID);
            return View(tilaukset);
        }

        // GET: Tilaus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            return View(tilaukset);
        }

        // POST: Tilaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            db.Tilaukset.Remove(tilaukset);
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
