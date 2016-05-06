using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointJalkahoitolaMVC.Database1;

namespace PointJalkahoitolaMVC.Controllers
{
    public class RekisteroinnitController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Rekisteroinnit
        public ActionResult Index()
        {
            var rekisterointi = db.Rekisterointi.Include(r => r.Hoitajat).Include(r => r.Kurssit);
            return View(rekisterointi.ToList());
        }

        // GET: Rekisteroinnit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekisterointi rekisterointi = db.Rekisterointi.Find(id);
            if (rekisterointi == null)
            {
                return HttpNotFound();
            }
            return View(rekisterointi);
        }

        // GET: Rekisteroinnit/Create
        public ActionResult Create()
        {
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "HoitajaID", "Etunimi");
            ViewBag.Kurssi_ID = new SelectList(db.Kurssit, "Kurssi_ID", "Nimike");
            return View();
        }

        // POST: Rekisteroinnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kurssi_ID,Kurssi,Hoitaja_ID")] Rekisterointi rekisterointi)
        {
            if (ModelState.IsValid)
            {
                db.Rekisterointi.Add(rekisterointi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "HoitajaID", "Etunimi", rekisterointi.Hoitaja_ID);
            ViewBag.Kurssi_ID = new SelectList(db.Kurssit, "Kurssi_ID", "Nimike", rekisterointi.Kurssi_ID);
            return View(rekisterointi);
        }

        // GET: Rekisteroinnit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekisterointi rekisterointi = db.Rekisterointi.Find(id);
            if (rekisterointi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "HoitajaID", "Etunimi", rekisterointi.Hoitaja_ID);
            ViewBag.Kurssi_ID = new SelectList(db.Kurssit, "Kurssi_ID", "Nimike", rekisterointi.Kurssi_ID);
            return View(rekisterointi);
        }

        // POST: Rekisteroinnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kurssi_ID,Kurssi,Hoitaja_ID")] Rekisterointi rekisterointi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rekisterointi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "HoitajaID", "Etunimi", rekisterointi.Hoitaja_ID);
            ViewBag.Kurssi_ID = new SelectList(db.Kurssit, "Kurssi_ID", "Nimike", rekisterointi.Kurssi_ID);
            return View(rekisterointi);
        }

        // GET: Rekisteroinnit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rekisterointi rekisterointi = db.Rekisterointi.Find(id);
            if (rekisterointi == null)
            {
                return HttpNotFound();
            }
            return View(rekisterointi);
        }

        // POST: Rekisteroinnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rekisterointi rekisterointi = db.Rekisterointi.Find(id);
            db.Rekisterointi.Remove(rekisterointi);
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
