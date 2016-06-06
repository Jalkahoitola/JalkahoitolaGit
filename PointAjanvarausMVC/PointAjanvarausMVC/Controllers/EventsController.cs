using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointAjanvarausMVC.Models;
using Microsoft.Ajax.Utilities;
using System.Globalization;

namespace PointAjanvarausMVC.Controllers
{
    public class EventsController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Events


        public ActionResult Index()
        {
            return View(db.Event.ToList());
        }

        //31.5.2016Lisätty näkymien suodatukset:
        public ActionResult OrderByFirstName()
        {
            var asiakkaat = from a in db.Asiakkaat
                            orderby a.Etunimi ascending
                            select a;
            return View(asiakkaat);
        }
        public ActionResult OrderByLastName()
        {
            var asiakkaat = from a in db.Asiakkaat
                            orderby a.Sukunimi ascending
                            select a;
            return View(asiakkaat);
        }//31.5.2016 Lisätty

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", "Sukunimi");
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi");
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Etunimi", "Sukunimi");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Varaus_ID,Päivämäärä,Varausaika,Asiakas_ID,Palvelu_ID,Hoitopaikka_ID,Hoitopaikan_Nimi, Hoitopaikan_Numero,Hoitaja_ID,Info")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Event.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", "Sukunimi", @event.Asiakas_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", @event.Palvelu_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero", @event.Hoitopaikka_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Etunimi", "Sukunimi", @event.Hoitaja_ID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", "Sukunimi", @event.Asiakas_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", @event.Palvelu_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero", @event.Hoitopaikka_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Etunimi", "Sukunimi", @event.Hoitaja_ID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Varaus_ID,Päivämäärä,Varausaika,Asiakas_ID,Palvelu_ID,Hoitopaikka_ID,Hoitopaikan_Nimi, Hoitopaikan_Numero,Hoitaja_ID,Info")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", "Sukunimi", @event.Asiakas_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", @event.Palvelu_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero", @event.Hoitopaikka_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Etunimi", "Sukunimi", @event.Hoitaja_ID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
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

        public class SamplesCultureInfo
        {

            public static void Main()
            {

                // Creates and initializes a CultureInfo.
                CultureInfo myCI = new CultureInfo("fi", false);

                // Clones myCI and modifies the DTFI and NFI instances associated with the clone.
                CultureInfo myCIclone = (CultureInfo)myCI.Clone();
                
                myCIclone.DateTimeFormat.DateSeparator = ".";
            

                // Displays the properties of the DTFI and NFI instances associated with the original and with the clone. 
                Console.WriteLine("DTFI/NFI PROPERTY\tORIGINAL\tMODIFIED CLONE");
                
                Console.WriteLine("DTFI.DateSeparator\t{0}\t\t{1}", myCI.DateTimeFormat.DateSeparator, myCIclone.DateTimeFormat.DateSeparator);
                
            

            }

        }

    }
}
