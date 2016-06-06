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
    public class RekisteroinnitController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Rekisteroinnit
        public ActionResult Index()
        {
            return View(db.Rekisterointi.ToList());
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
            return View();
        }

        // POST: Rekisteroinnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rekisterointi_ID,Vuosikurssi,Vuosikurssi_aloitus_pvm,Vuosikurssi_lopetus_pvm,Kurssi_ID,Hoitaja_ID")] Rekisterointi rekisterointi)
        {
            if (ModelState.IsValid)
            {
                db.Rekisterointi.Add(rekisterointi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(rekisterointi);
        }

        // POST: Rekisteroinnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rekisterointi_ID,Vuosikurssi,Vuosikurssi_aloitus_pvm,Vuosikurssi_lopetus_pvm,Kurssi_ID,Hoitaja_ID")] Rekisterointi rekisterointi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rekisterointi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
