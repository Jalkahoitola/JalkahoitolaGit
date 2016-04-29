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
    public class PuhelimetController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Puhelimet
        public ActionResult Index()
        {
            return View(db.Puhelintiedot.ToList());
        }

        // GET: Puhelimet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelintiedot puhelintiedot = db.Puhelintiedot.Find(id);
            if (puhelintiedot == null)
            {
                return HttpNotFound();
            }
            return View(puhelintiedot);
        }

        // GET: Puhelimet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puhelimet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PuhelintietoID,Puhelin_1,Puhelin_2,Puhelin_3")] Puhelintiedot puhelintiedot)
        {
            if (ModelState.IsValid)
            {
                db.Puhelintiedot.Add(puhelintiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puhelintiedot);
        }

        // GET: Puhelimet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelintiedot puhelintiedot = db.Puhelintiedot.Find(id);
            if (puhelintiedot == null)
            {
                return HttpNotFound();
            }
            return View(puhelintiedot);
        }

        // POST: Puhelimet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PuhelintietoID,Puhelin_1,Puhelin_2,Puhelin_3")] Puhelintiedot puhelintiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puhelintiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puhelintiedot);
        }

        // GET: Puhelimet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelintiedot puhelintiedot = db.Puhelintiedot.Find(id);
            if (puhelintiedot == null)
            {
                return HttpNotFound();
            }
            return View(puhelintiedot);
        }

        // POST: Puhelimet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puhelintiedot puhelintiedot = db.Puhelintiedot.Find(id);
            db.Puhelintiedot.Remove(puhelintiedot);
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
