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
    public class KurssiController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Kurssi
        public ActionResult Index()
        {
            var kurssit = db.Kurssit.Include(k => k.Rekisterointi);
            return View(kurssit.ToList());
        }

        // GET: Kurssi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssit kurssit = db.Kurssit.Find(id);
            if (kurssit == null)
            {
                return HttpNotFound();
            }
            return View(kurssit);
        }

        // GET: Kurssi/Create
        public ActionResult Create()
        {
            ViewBag.Kurssi_ID = new SelectList(db.Rekisterointi, "Kurssi_ID", "Kurssi");
            return View();
        }

        // POST: Kurssi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kurssi_ID,Nimike,Opintopisteet,Arviointi")] Kurssit kurssit)
        {
            if (ModelState.IsValid)
            {
                db.Kurssit.Add(kurssit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kurssi_ID = new SelectList(db.Rekisterointi, "Kurssi_ID", "Kurssi", kurssit.Kurssi_ID);
            return View(kurssit);
        }

        // GET: Kurssi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssit kurssit = db.Kurssit.Find(id);
            if (kurssit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kurssi_ID = new SelectList(db.Rekisterointi, "Kurssi_ID", "Kurssi", kurssit.Kurssi_ID);
            return View(kurssit);
        }

        // POST: Kurssi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kurssi_ID,Nimike,Opintopisteet,Arviointi")] Kurssit kurssit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurssit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kurssi_ID = new SelectList(db.Rekisterointi, "Kurssi_ID", "Kurssi", kurssit.Kurssi_ID);
            return View(kurssit);
        }

        // GET: Kurssi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssit kurssit = db.Kurssit.Find(id);
            if (kurssit == null)
            {
                return HttpNotFound();
            }
            return View(kurssit);
        }

        // POST: Kurssi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurssit kurssit = db.Kurssit.Find(id);
            db.Kurssit.Remove(kurssit);
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
