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
    public class PalveluController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Palvelu
        public ActionResult Index()
        {
            return View(db.Palvelut.ToList());
        }

        // GET: Palvelu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            return View(palvelut);
        }

        // GET: Palvelu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Palvelu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PalveluID,Palvelu,Palvelun_kesto")] Palvelut palvelut)
        {
            if (ModelState.IsValid)
            {
                db.Palvelut.Add(palvelut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palvelut);
        }

        // GET: Palvelu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            return View(palvelut);
        }

        // POST: Palvelu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PalveluID,Palvelu,Palvelun_kesto")] Palvelut palvelut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palvelut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palvelut);
        }

        // GET: Palvelu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelut palvelut = db.Palvelut.Find(id);
            if (palvelut == null)
            {
                return HttpNotFound();
            }
            return View(palvelut);
        }

        // POST: Palvelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palvelut palvelut = db.Palvelut.Find(id);
            db.Palvelut.Remove(palvelut);
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
