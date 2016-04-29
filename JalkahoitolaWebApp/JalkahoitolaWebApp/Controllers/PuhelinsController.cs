using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JalkahoitolaWebApp.Models;

namespace JalkahoitolaWebApp.Controllers
{
    public class PuhelinsController : Controller
    {
        private Jalkahoitola_dbEntities db = new Jalkahoitola_dbEntities();

        // GET: Puhelins
        public ActionResult Index()
        {
            return View(db.Puhelin.ToList());
        }

        // GET: Puhelins/Details/5
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

        // GET: Puhelins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puhelins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Puhelin_ID,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Puhelin.Add(puhelin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puhelin);
        }

        // GET: Puhelins/Edit/5
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
            return View(puhelin);
        }

        // POST: Puhelins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Puhelin_ID,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puhelin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puhelin);
        }

        // GET: Puhelins/Delete/5
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

        // POST: Puhelins/Delete/5
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
