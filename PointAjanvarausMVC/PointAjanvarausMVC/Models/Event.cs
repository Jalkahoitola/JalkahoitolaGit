//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointAjanvarausMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int Varaus_ID { get; set; }
        public Nullable<System.DateTime> Päivämäärä { get; set; }
        public Nullable<System.DateTime> Varausaika { get; set; }
        public Nullable<int> Asiakas_ID { get; set; }
        public Nullable<int> Palvelu_ID { get; set; }
        public Nullable<int> Hoitopaikka_ID { get; set; }
        public Nullable<int> Hoitaja_ID { get; set; }
        public string Info { get; set; }
    
        public virtual Hoitopaikat Hoitopaikat { get; set; }
        public virtual Asiakkaat Asiakkaat { get; set; }
        public virtual Palvelut Palvelut { get; set; }
        public virtual Hoitajat Hoitajat { get; set; }
    }
}
