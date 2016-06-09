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
    
    public partial class Palvelut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Palvelut()
        {
            this.Event = new HashSet<Event>();
            this.Varaus = new HashSet<Varaus>();
        }
    
        public int Palvelu_ID { get; set; }
        public string Palvelun_nimi { get; set; }
        public string Palvelun_kesto { get; set; }
        public Nullable<int> Asiakas_id { get; set; }
        public Nullable<int> Hoitaja_id { get; set; }
        public Nullable<int> Toimipiste_id { get; set; }
        public Nullable<int> Varaus_id { get; set; }
    
        public virtual Asiakkaat Asiakkaat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
        public virtual Toimipisteet Toimipisteet { get; set; }
        public virtual Hoitajat Hoitajat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varaus> Varaus { get; set; }
    }
}
