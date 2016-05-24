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
    public class ShipperController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Shipper
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(s => s.Huomiot1).Include(s => s.Osoite).Include(s => s.Puhelin);
            return View(shippers.ToList());
        }

        // GET: Shipper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            return View(shippers);
        }

        // GET: Shipper/Create
        public ActionResult Create()
        {
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut");
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            return View();
        }

        // POST: Shipper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Shipper_ID,Yritysnimi,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shippers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", shippers.Huomio_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", shippers.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", shippers.Puhelin_id);
            return View(shippers);
        }

        // GET: Shipper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", shippers.Huomio_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", shippers.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", shippers.Puhelin_id);
            return View(shippers);
        }

        // POST: Shipper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Shipper_ID,Yritysnimi,Puhelinnumero_1,Huomiot,Osoite_id,Huomio_id,Puhelin_id")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Huomio_id = new SelectList(db.Huomiot, "Huomio_ID", "Muut", shippers.Huomio_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", shippers.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", shippers.Puhelin_id);
            return View(shippers);
        }

        // GET: Shipper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            return View(shippers);
        }

        // POST: Shipper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            db.Shippers.Remove(shippers);
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
