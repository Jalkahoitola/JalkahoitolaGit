using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAjanvarausMVC.Models
{
    class RekisteriArkisto
    {
        public int RekisteriId { get; set; }
        public int HoitajaId { get; set; }
        public string VuosikurssiArkisto { get; set; }
        public int Id { get; set; }
        public string Tunnari { get; set; }
        public string ArkistoituEtunimi { get; set; }
        public string ArkistoituSukunimi { get; set; }
        public string ArkistoVuosikurssi { get; set; }
        public string ArkistointiPvm { get; set; }
        public string TiedotArkistoitu { get; set; }
    }
}
