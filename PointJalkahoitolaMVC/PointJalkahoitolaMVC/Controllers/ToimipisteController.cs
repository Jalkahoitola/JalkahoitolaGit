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
    public class ToimipisteController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Toimipiste
        public ActionResult Index()
        {
            return View(db.Toimipisteet.ToList());
        }

        // GET: Toimipiste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            return View(toimipisteet);
        }

        // GET: Toimipiste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toimipiste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToimipisteID,Toimipisteen_Nimi,Hoitopaikat,Osoite")] Toimipisteet toimipisteet)
        {
            if (ModelState.IsValid)
            {
                db.Toimipisteet.Add(toimipisteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toimipisteet);
        }

        // GET: Toimipiste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            return View(toimipisteet);
        }

        // POST: Toimipiste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToimipisteID,Toimipisteen_Nimi,Hoitopaikat,Osoite")] Toimipisteet toimipisteet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toimipisteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toimipisteet);
        }

        // GET: Toimipiste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            if (toimipisteet == null)
            {
                return HttpNotFound();
            }
            return View(toimipisteet);
        }

        // POST: Toimipiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toimipisteet toimipisteet = db.Toimipisteet.Find(id);
            db.Toimipisteet.Remove(toimipisteet);
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
