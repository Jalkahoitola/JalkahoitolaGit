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
    public class OsoitteetController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Osoitteet
        public ActionResult Index()
        {
            return View(db.Osoite.ToList());
        }

        // GET: Osoitteet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // GET: Osoitteet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osoitteet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Osoite_ID,Katuosoite,Postinumero,Postitoimipaikka")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Osoite.Add(osoite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osoite);
        }

        // GET: Osoitteet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // POST: Osoitteet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Osoite_ID,Katuosoite,Postinumero,Postitoimipaikka")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osoite);
        }

        // GET: Osoitteet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // POST: Osoitteet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoite osoite = db.Osoite.Find(id);
            db.Osoite.Remove(osoite);
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
