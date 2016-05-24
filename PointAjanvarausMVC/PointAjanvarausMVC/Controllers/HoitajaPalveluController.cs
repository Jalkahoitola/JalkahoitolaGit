using PointAjanvarausMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointAjanvarausMVC.Controllers
{
    public class HoitajaPalveluController : Controller
    {
        // GET: HoitajaPalvelu
        public ActionResult Index()
        {
                JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
                List<Hoitajat> model = entities.Hoitajat.ToList();
                entities.Dispose();

                return View(model);
            }
          
        
        public ActionResult Getpalvelut(int? id)
        {
            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            List<Palvelut> palvelut = (from p in entities.Palvelut
                                       where p.Palvelu_ID == id
                                       select p).ToList();

            List<HoitajatietoData> result = new List<HoitajatietoData>();

            foreach (Palvelut palvelu in palvelut)
            {
                HoitajatietoData data = new HoitajatietoData();

                data.Hoitaja_ID = (int)(palvelu.Hoitaja_id);
                data.PalvelunNimi = palvelu.Palvelu_ID.ToString();
                data.Palvelu_ID = palvelu.Palvelu_ID;


                List<Hoitajat> hoitajat = (from h in entities.Hoitajat
                                           where h.Hoitaja_ID == palvelu.Hoitaja_id
                                           select h).ToList();
                data.EtunimiNimi = hoitajat[0].Etunimi;
                data.SukunimiNimi = hoitajat[0].Sukunimi;
                //data.PalvelunKesto = (double)(palvelu.Palvelun_kesto);


                result.Add(data);

            }

            entities.Dispose();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}
