using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointAjanvarausMVC.Models;
using System.Globalization;

namespace PointAjanvarausMVC.Controllers
{
    public class VarauksetController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Varaukset
        public ActionResult Index()
        {
            var varaus = db.Varaus.Include(v => v.Asiakkaat).Include(v => v.Hoitajat).Include(v => v.Hoitopaikat).Include(v => v.Palvelut).Include(v => v.Toimipisteet);
            return View(varaus.ToList());
        }

        //14.6.2016 Lisätty tietokantataulujen suodatukset:
        public ActionResult OrderByPvm()
        {
            var varaus = from v in db.Varaus
                            orderby v.pvm ascending
                            select v;
            return View(varaus);
        }
        public ActionResult OrderByAlku()
        {
            var varaus = from v in db.Varaus
                         orderby v.Alku ascending
                         select v;
            return View(varaus);
        }
        public ActionResult OrderByPalvelun_nimi()
        {
            var varaus = from v in db.Varaus
                         orderby v.Palvelun_nimi ascending
                         select v;
            return View(varaus);
        }//<--14.6.2016 Lisätty

        // GET: Varaukset/Details/5
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

        // GET: Varaukset/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero");
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi");
            ViewBag.Toimipiste_ID = new SelectList(db.Palvelut, "Toimipiste_ID", "Toimipisteen_nimi");
            return View();
        }

        // POST: Varaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Varaus_ID,Hoitaja_ID,Hoitopaikka_ID,Asiakas_ID,Alku,Loppu,Palvelun_nimi,Palvelu_ID,Info,Type,pvm")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                db.Varaus.Add(varaus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CultureInfo fiFi = new CultureInfo("fi-FI");

            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", varaus.Asiakas_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", varaus.Hoitaja_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero",varaus.Hoitopaikka_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", varaus.Palvelu_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Palvelut, "Toimipiste_ID", "Toimipisteen_nimi", varaus.Toimipiste_ID);
            return View(varaus);
        }


        //Varauksen tietojen muuttaminen
        //https://www.youtube.com/watch?v=l06JSQDuOwo
        //OHJE
        //https://msdn.microsoft.com/fi-fi/data/jj592676


        public ActionResult Resize(int id, DateTime pvm, string newStart, string newEnd)
        {
            using (var dp = new JohaMeriSQL2Entities())
            {
                var varaus = dp.Varaus.First(c => c.Varaus_ID == id);

                varaus.pvm = pvm;
                varaus.Alku = newStart;
                varaus.Loppu = newEnd;
                //varaus.sisalto = "PÄIVITETTY_2 19.5.2016";
                dp.SaveChanges();
            }

            return new EmptyResult();
        }

        // GET: Varaukset/Edit/5
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
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", varaus.Asiakas_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", varaus.Hoitaja_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero", varaus.Hoitopaikka_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", varaus.Palvelu_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Palvelut, "Toimipiste_ID", "Toimipisteen_nimi", varaus.Toimipiste_ID);
            return View(varaus);
        }

        // POST: Varaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Varaus_ID,Hoitaja_ID,Hoitopaikka_ID,Asiakas_ID,Alku,Loppu,Palvelun_nimi,Palvelu_ID,Info,Type,pvm")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                CultureInfo fiFi = new CultureInfo("fi-FI");
                db.Entry(varaus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Asiakastunnus", varaus.Asiakas_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", varaus.Hoitaja_ID);
            ViewBag.Hoitopaikka_ID = new SelectList(db.Hoitopaikat, "Hoitopaikka_ID", "Hoitopaikan_Nimi", "Hoitopaikan_Numero", varaus.Hoitopaikka_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", varaus.Palvelu_ID);
            ViewBag.Toimipiste_ID = new SelectList(db.Palvelut, "Toimipiste_ID", "Toimipisteen_nimi", varaus.Toimipiste_ID);
            return View(varaus);
        }

        // GET: Varaukset/Delete/5
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

        // POST: Varaukset/Delete/5
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
