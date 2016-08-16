using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PointAjanvarausMVC.Models;
using AssetManagementWEBjm.Utilities;
using System.Globalization;

namespace PointAjanvarausMVC.Controllers
{
    public class ArkistoController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: Arkisto
        public ActionResult Index()
        {
            var arkistot = db.Arkistot.Include(a => a.Osoite).Include(a => a.Puhelin).Include(a => a.Huomiot).Include(a => a.Asiakkaat).Include(a => a.Varaus).Include(a => a.Palvelut).Include(a => a.Hoitajat);
            return View(arkistot.ToList());
        }

        //17.6.2016 lisätty arkistointi näkymä:
        //tehdään listaus kaikista kytkennöistä
        public ActionResult List()
        {
            List<AjanvarausModel> model = new List<AjanvarausModel>();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
            try
            {
                List<Arkistot> tunnukset = entities.Arkistot.ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta

                CultureInfo fiFi = new CultureInfo("fi-FI");
                foreach (Arkistot tunnus in tunnukset)
                {
                    AjanvarausModel view = new AjanvarausModel();
                    view.HoitajaId = tunnus.Hoitaja_ID;
                    view.RekisteriId = tunnus.Rekisterointi_ID;
                    view.Tunnari = tunnus.Hoitajat.Tunnus;
                    view.ArkistoituEtunimi = tunnus.Hoitajat.Etunimi;
                    view.ArkistoituSukunimi = tunnus.Hoitajat.Sukunimi;
                    view.ArkistoVuosikurssi = tunnus.Hoitajat.Tiedot_arkistoitu;
                    view.TiedotArkistoitu = tunnus.Hoitajat.Tiedot_arkistoitu + ": " + tunnus.Hoitajat.Tunnus;
                    view.ArkistointiPvm = tunnus.ArkistointiPvm.Value.ToString(fiFi);

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }
        public ActionResult ListJson()
        {
            List<AjanvarausModel> model = new List<AjanvarausModel>();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
            try
            {
                List<Arkistot> tunnukset = entities.Arkistot.ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                CultureInfo fiFi = new CultureInfo("fi-FI");
                foreach (Arkistot tunnus in tunnukset)
                {
                    AjanvarausModel view = new AjanvarausModel();
                    view.HoitajaId = tunnus.Hoitaja_ID;
                    view.RekisteriId = tunnus.Rekisterointi_ID;
                    view.Tunnari = tunnus.Hoitajat.Tunnus;
                    view.ArkistoituEtunimi = tunnus.Hoitajat.Etunimi;
                    view.ArkistoituSukunimi = tunnus.Hoitajat.Sukunimi;
                    view.ArkistoVuosikurssi = tunnus.Hoitajat.Tiedot_arkistoitu;
                    view.TiedotArkistoitu = tunnus.Hoitajat.Tiedot_arkistoitu + ": " + tunnus.Hoitajat.Tunnus;
                    view.ArkistointiPvm = tunnus.ArkistointiPvm.Value.ToString(fiFi);

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //HOITAJATIEDON ARKISTOINTI (SQL) TIETOKANTAAN
        public JsonResult Arkistointi()
        {//ks. kansio Utilities:ReadToEnd->laajennusmetodi:
            string json = Request.InputStream.ReadToEnd();
            //uusi luokka:
            RekisteriArkisto inputData =
                JsonConvert.DeserializeObject<RekisteriArkisto>(json);

            bool success = false;
            string error = "";

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                //haetaan ensin hoitajan id-numero koodin perusteella:
                int HoitajaId = (from h in entities.Hoitajat
                                 where h.Tunnus == inputData.Tunnari
                                 select h.Hoitaja_ID).FirstOrDefault();

                //haetaan reksiteri id-numero koodin perusteella:
                int RekisteriId = (from r in entities.Rekisterointi
                                   where r.Vuosikurssi == inputData.ArkistoVuosikurssi
                                   select r.Rekisterointi_ID).FirstOrDefault();

                if ((HoitajaId > 0) && (RekisteriId > 0))
                {
                    //tallennetaan hoitajatieto Arkistointikantaan:
                    Arkistot newEntry = new Arkistot();
                    newEntry.Rekisterointi_ID = RekisteriId;
                    newEntry.Hoitaja_ID = HoitajaId;
                    //newEntry.Tiedot_arkistoitu = tiedot_arkistoitu.ToString();
                    newEntry.ArkistointiPvm = DateTime.Now;

                    entities.Arkistot.Add(newEntry);
                    entities.SaveChanges();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            //palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);
        }//<--17.6.2016 lisätty arkistointi näkymä


        // GET: Arkisto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arkistot arkistot = db.Arkistot.Find(id);
            if (arkistot == null)
            {
                return HttpNotFound();
            }
            return View(arkistot);
        }

        // GET: Arkisto/Create
        public ActionResult Create()
        {
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite");
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1");
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut");
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi");
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Alku");
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi");
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus");
            return View();
        }

        // POST: Arkisto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Arkisto_ID,Tunnus,Etunimi,Toinen_nimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Aloituspvm,Valmistumispvm,Keskeytyspvm,Tiedot_arkistoitu,Huomio_ID,Osoite_ID,Puhelin_ID,Kurssi_ID,Rekisterointi_ID,Palvelu_ID,Asiakas_ID,Varaus_ID,Sahkoposti,Puhelinnumero_1,Hoitaja_ID")] Arkistot arkistot)
        {
            if (ModelState.IsValid)
            {
                db.Arkistot.Add(arkistot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", arkistot.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", arkistot.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", arkistot.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", arkistot.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Alku", arkistot.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", arkistot.Palvelu_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", arkistot.Hoitaja_ID);
            return View(arkistot);
        }

        // GET: Arkisto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arkistot arkistot = db.Arkistot.Find(id);
            if (arkistot == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", arkistot.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", arkistot.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", arkistot.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", arkistot.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Alku", arkistot.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", arkistot.Palvelu_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", arkistot.Hoitaja_ID);
            return View(arkistot);
        }

        // POST: Arkisto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Arkisto_ID,Tunnus,Etunimi,Toinen_nimi,Sukunimi,Katuosoite,Postinumero,Postitoimipaikka,Henkilotunnus,Aloituspvm,Valmistumispvm,Keskeytyspvm,Tiedot_arkistoitu,Huomio_ID,Osoite_ID,Puhelin_ID,Kurssi_ID,Rekisterointi_ID,Palvelu_ID,Asiakas_ID,Varaus_ID,Sahkoposti,Puhelinnumero_1,Hoitaja_ID")] Arkistot arkistot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arkistot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_ID = new SelectList(db.Osoite, "Osoite_ID", "Katuosoite", arkistot.Osoite_ID);
            ViewBag.Puhelin_ID = new SelectList(db.Puhelin, "Puhelin_ID", "Puhelinnumero_1", arkistot.Puhelin_ID);
            ViewBag.Huomio_ID = new SelectList(db.Huomiot, "Huomio_ID", "Muut", arkistot.Huomio_ID);
            ViewBag.Asiakas_ID = new SelectList(db.Asiakkaat, "Asiakas_ID", "Etunimi", arkistot.Asiakas_ID);
            ViewBag.Varaus_ID = new SelectList(db.Varaus, "Varaus_ID", "Alku", arkistot.Varaus_ID);
            ViewBag.Palvelu_ID = new SelectList(db.Palvelut, "Palvelu_ID", "Palvelun_nimi", arkistot.Palvelu_ID);
            ViewBag.Hoitaja_ID = new SelectList(db.Hoitajat, "Hoitaja_ID", "Tunnus", arkistot.Hoitaja_ID);
            return View(arkistot);
        }

        // GET: Arkisto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arkistot arkistot = db.Arkistot.Find(id);
            if (arkistot == null)
            {
                return HttpNotFound();
            }
            return View(arkistot);
        }

        // POST: Arkisto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arkistot arkistot = db.Arkistot.Find(id);
            db.Arkistot.Remove(arkistot);
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
