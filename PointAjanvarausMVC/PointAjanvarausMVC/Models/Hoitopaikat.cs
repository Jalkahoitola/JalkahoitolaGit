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
    
    public partial class Hoitopaikat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoitopaikat()
        {
            this.Event = new HashSet<Event>();
            this.Varauskalenteri = new HashSet<Varauskalenteri>();
            this.Toimipisteet1 = new HashSet<Toimipisteet>();
            this.Varaus = new HashSet<Varaus>();
        }
    
        public int Hoitopaikka_ID { get; set; }
        public string Hoitopaikan_Nimi { get; set; }
        public string Hoitopaikan_Numero { get; set; }
        public Nullable<int> Toimipiste_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varauskalenteri> Varauskalenteri { get; set; }
        public virtual Toimipisteet Toimipisteet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Toimipisteet> Toimipisteet1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varaus> Varaus { get; set; }
    }
}