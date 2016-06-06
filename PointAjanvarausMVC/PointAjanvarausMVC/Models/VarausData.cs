using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAjanvarausMVC.Models
{
    public class VarausData
    {
        public int ID { get; set; }
        //public int opiskelija_id { get; set; }
        //public int hoitopaikka_id { get; set; }
        //public int asiakas_id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string text { get; set; }
    }
}
