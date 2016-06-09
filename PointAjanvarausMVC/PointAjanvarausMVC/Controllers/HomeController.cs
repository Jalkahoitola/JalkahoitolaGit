using PointAjanvarausMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointAjanvarausMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Selain = Request.UserAgent;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Home/GetVaraukset
        public ActionResult GetVaraukset(string Alku, string Loppu)
        {
            var a = Convert.ToDateTime(Alku);
            var l = Convert.ToDateTime(Loppu);

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
            List<Varaus> varaukset = (from o in entities.Varaus
                                      where (o.pvm >= a && o.pvm < l)
                                      //where ( o.alku >= Convert.ToDateTime(alku) && o.loppu < Convert.ToDateTime(loppu) )
                                      //orderby o.datetime ascending
                                      select o).ToList();
            entities.Dispose();

            List<VarausData> result = new List<VarausData>();
            foreach (Varaus c in varaukset)
            {

                VarausData data = new VarausData();
                data.ID = c.Varaus_ID;
                //data.opiskelija_id = Convert.ToInt32(c.opiskelija_id);
                //data.hoitopaikka_id = Convert.ToInt32(c.hoitopaikka_id);
                //data.asiakas_id = Convert.ToInt32(c.asiakas_id);


                data.Pvm = Convert.ToDateTime(c.pvm);
                data.startTime = c.Alku.ToString();
                data.endTime = c.Loppu.ToString();
                data.text = c.sisalto + " ID: " + c.Varaus_ID + " ALKU: " + c.Alku + " LOPPU: " + c.Loppu;

                result.Add(data);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}





