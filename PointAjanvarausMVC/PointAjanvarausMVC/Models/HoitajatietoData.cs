using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAjanvarausMVC.Models
{
    public class HoitajatietoData
    {
        public String EtunimiNimi { get; set; }
        public String SukunimiNimi { get; set; }
        public int Hoitaja_ID { get; set; }
        public int Palvelu_ID { get; set; }
        public int Asiakas_ID { get; set; }
        public String PalvelunNimi { get; set; }
        public double PalvelunKesto { get; set; }
        public double Palvelun_kesto { get; set; }
    }
}
