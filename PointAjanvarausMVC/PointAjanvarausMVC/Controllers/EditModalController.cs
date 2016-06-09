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
    public class EditModalController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: EditModal
        public ActionResult Index()
        {
            return View(db.Varaus.ToList());
        }

        // GET: EditModal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }
            return View(varaus);
        }

        // GET: EditModal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditModal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Varaus_ID,Type,Hoitaja_ID,Hoitopaikka_ID,Asiakas_ID,pvm,Alku,Loppu,Info")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                db.Varaus.Add(varaus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(varaus);
        }

        // GET: EditModal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }
            return View(varaus);
        }

        // POST: EditModal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Varaus_ID,Type,Hoitaja_ID,Hoitopaikka_ID,Asiakas_ID,pvm,Alku,Loppu,Info")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varaus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(varaus);
        }

        // GET: EditModal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }
            return View(varaus);
        }

        // POST: EditModal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Varaus varaus = db.Varaus.Find(id);
            db.Varaus.Remove(varaus);
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
