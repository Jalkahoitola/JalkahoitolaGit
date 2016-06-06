using System;
using System.ComponentModel.DataAnnotations;

namespace PointAjanvarausMVC.Models
{
    internal class ApplyFormatInEditModeAttribute : Attribute
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public object Päivämäärä;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public object Varausaika;

    }

}