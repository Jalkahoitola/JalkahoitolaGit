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
    public class HoitopaikkaController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Hoitopaikka
        public ActionResult Index()
        {
            var hoitopaikat = db.Hoitopaikat.Include(h => h.Toimipisteet);
            return View(hoitopaikat.ToList());
        }

        // GET: Hoitopaikka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikat hoitopaikat = db.Hoitopaikat.Find(id);
            if (hoitopaikat == null)
            {
                return HttpNotFound();
            }
            return View(hoitopaikat);
        }

        // GET: Hoitopaikka/Create
        public ActionResult Create()
        {
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi");
            return View();
        }

        // POST: Hoitopaikka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hoitopaikka_ID,Hoitopaikan_Nimi,Hoitopaikan_Numero, Toimipisteen_Nimi,Toimipiste_ID")] Hoitopaikat hoitopaikat)
        {
            if (ModelState.IsValid)
            {
                db.Hoitopaikat.Add(hoitopaikat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", hoitopaikat.Toimipiste_ID);
            return View(hoitopaikat);
        }

        // GET: Hoitopaikka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikat hoitopaikat = db.Hoitopaikat.Find(id);
            if (hoitopaikat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", hoitopaikat.Toimipiste_ID);
            return View(hoitopaikat);
        }

        // POST: Hoitopaikka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hoitopaikka_ID,Hoitopaikan_Nimi,Hoitopaikan_Numero,Toimipisteen_Nimi,Toimipiste_ID")] Hoitopaikat hoitopaikat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoitopaikat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Toimipiste_ID = new SelectList(db.Toimipisteet, "Toimipiste_ID", "Toimipisteen_Nimi", hoitopaikat.Toimipiste_ID);
            return View(hoitopaikat);
        }

        // GET: Hoitopaikka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikat hoitopaikat = db.Hoitopaikat.Find(id);
            if (hoitopaikat == null)
            {
                return HttpNotFound();
            }
            return View(hoitopaikat);
        }

        // POST: Hoitopaikka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoitopaikat hoitopaikat = db.Hoitopaikat.Find(id);
            db.Hoitopaikat.Remove(hoitopaikat);
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
