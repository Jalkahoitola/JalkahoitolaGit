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
    
    public partial class Huomiot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huomiot()
        {
            this.Toimipisteet = new HashSet<Toimipisteet>();
            this.Henkilokunta = new HashSet<Henkilokunta>();
            this.Shippers = new HashSet<Shippers>();
            this.Hoitajat = new HashSet<Hoitajat>();
            this.Asiakkaat = new HashSet<Asiakkaat>();
        }
    
        public int Huomio_ID { get; set; }
        public string Muut { get; set; }
        public string Huomioitavat_asiat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Toimipisteet> Toimipisteet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Henkilokunta> Henkilokunta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shippers> Shippers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoitajat> Hoitajat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asiakkaat> Asiakkaat { get; set; }
    }
}
