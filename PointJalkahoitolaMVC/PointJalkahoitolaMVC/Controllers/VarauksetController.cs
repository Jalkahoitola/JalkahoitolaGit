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
    public class VarauksetController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Varaukset
        public ActionResult Index()
        {
            return View(db.Varauskalenteri.ToList());
        }

        // GET: Varaukset/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varauskalenteri varauskalenteri = db.Varauskalenteri.Find(id);
            if (varauskalenteri == null)
            {
                return HttpNotFound();
            }
            return View(varauskalenteri);
        }

        // GET: Varaukset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Varaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VarausID,Päivämäärä,Aika,AsiakasID,PalveluID,Hoitopaikka,HoitajaID")] Varauskalenteri varauskalenteri)
        {
            if (ModelState.IsValid)
            {
                db.Varauskalenteri.Add(varauskalenteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(varauskalenteri);
        }

        // GET: Varaukset/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varauskalenteri varauskalenteri = db.Varauskalenteri.Find(id);
            if (varauskalenteri == null)
            {
                return HttpNotFound();
            }
            return View(varauskalenteri);
        }

        // POST: Varaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VarausID,Päivämäärä,Aika,AsiakasID,PalveluID,Hoitopaikka,HoitajaID")] Varauskalenteri varauskalenteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varauskalenteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(varauskalenteri);
        }

        // GET: Varaukset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varauskalenteri varauskalenteri = db.Varauskalenteri.Find(id);
            if (varauskalenteri == null)
            {
                return HttpNotFound();
            }
            return View(varauskalenteri);
        }

        // POST: Varaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Varauskalenteri varauskalenteri = db.Varauskalenteri.Find(id);
            db.Varauskalenteri.Remove(varauskalenteri);
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
