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
    public class PostitoimipaikatController : Controller
    {
        private JohaMeriSQL1Entities1 db = new JohaMeriSQL1Entities1();

        // GET: Postitoimipaikat
        public ActionResult Index()
        {
            return View(db.Postitoimipaikat1.ToList());
        }

        // GET: Postitoimipaikat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postitoimipaikat1 postitoimipaikat1 = db.Postitoimipaikat1.Find(id);
            if (postitoimipaikat1 == null)
            {
                return HttpNotFound();
            }
            return View(postitoimipaikat1);
        }

        // GET: Postitoimipaikat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postitoimipaikat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Postinumero,Postitoimipaikka")] Postitoimipaikat1 postitoimipaikat1)
        {
            if (ModelState.IsValid)
            {
                db.Postitoimipaikat1.Add(postitoimipaikat1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postitoimipaikat1);
        }

        // GET: Postitoimipaikat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postitoimipaikat1 postitoimipaikat1 = db.Postitoimipaikat1.Find(id);
            if (postitoimipaikat1 == null)
            {
                return HttpNotFound();
            }
            return View(postitoimipaikat1);
        }

        // POST: Postitoimipaikat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Postinumero,Postitoimipaikka")] Postitoimipaikat1 postitoimipaikat1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postitoimipaikat1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postitoimipaikat1);
        }

        // GET: Postitoimipaikat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postitoimipaikat1 postitoimipaikat1 = db.Postitoimipaikat1.Find(id);
            if (postitoimipaikat1 == null)
            {
                return HttpNotFound();
            }
            return View(postitoimipaikat1);
        }

        // POST: Postitoimipaikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Postitoimipaikat1 postitoimipaikat1 = db.Postitoimipaikat1.Find(id);
            db.Postitoimipaikat1.Remove(postitoimipaikat1);
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
