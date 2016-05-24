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
    public class HuomioController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Huomio
        public ActionResult Index()
        {
            return View(db.Huomiot.ToList());
        }

        // GET: Huomio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huomiot huomiot = db.Huomiot.Find(id);
            if (huomiot == null)
            {
                return HttpNotFound();
            }
            return View(huomiot);
        }

        // GET: Huomio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Huomio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Huomio_ID,Sairaudet,Muut")] Huomiot huomiot)
        {
            if (ModelState.IsValid)
            {
                db.Huomiot.Add(huomiot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(huomiot);
        }

        // GET: Huomio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huomiot huomiot = db.Huomiot.Find(id);
            if (huomiot == null)
            {
                return HttpNotFound();
            }
            return View(huomiot);
        }

        // POST: Huomio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Huomio_ID,Sairaudet,Muut")] Huomiot huomiot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huomiot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huomiot);
        }

        // GET: Huomio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huomiot huomiot = db.Huomiot.Find(id);
            if (huomiot == null)
            {
                return HttpNotFound();
            }
            return View(huomiot);
        }

        // POST: Huomio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Huomiot huomiot = db.Huomiot.Find(id);
            db.Huomiot.Remove(huomiot);
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
