using System;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAjanvarausMVC.Models
{
    class AjanvarausModel
    {
        public int Id { get; set; }
        public string Tunnari { get; set; }
        public string ArkistoituEtunimi { get; set; }
        public string ArkistoituSukunimi { get; set; }
        public string ArkistoVuosikurssi { get; set; }
        //Lisätty 30.8.2016-->
        [Display(Name = "ArkistointiPvm")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public string ArkistointiPvm { get; set; }
        public int HoitajaId { get; set; }
        public int RekisteriId { get; set; }
        public string TiedotArkistoitu { get; set; }
    }
}
