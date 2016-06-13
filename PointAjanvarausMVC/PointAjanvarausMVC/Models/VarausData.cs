using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAjanvarausMVC.Models
{
    public class VarausData
    {
        public int ID { get; set; }
        public int type { get; set; }
        //public int opiskelija_id { get; set; }
        //public int hoitopaikka_id { get; set; }
        //public int asiakas_id { get; set; }
        public DateTime Pvm { get; set; }

        [Display(Name = "Pvm")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:Dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> pvm { get; set; }




        public string startTime { get; set; }
        public string endTime { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string text { get; set; }
        public DateTime newStart { get; set; }
        public DateTime newEnd { get; set; }

    }
}
