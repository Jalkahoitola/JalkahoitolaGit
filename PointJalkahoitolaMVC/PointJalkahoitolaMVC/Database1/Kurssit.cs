//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointJalkahoitolaMVC.Database1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kurssit
    {
        public int Kurssi_ID { get; set; }
        public string Nimike { get; set; }
        public Nullable<int> Opintopisteet { get; set; }
        public string Arviointi { get; set; }
    
        public virtual Rekisterointi Rekisterointi { get; set; }
    }
}
