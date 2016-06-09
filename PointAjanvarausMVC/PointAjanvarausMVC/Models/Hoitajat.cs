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
    
    public partial class Hoitajat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoitajat()
        {
            this.Event = new HashSet<Event>();
            this.Palvelut = new HashSet<Palvelut>();
            this.Kurssi = new HashSet<Kurssi>();
            this.Rekisterointi = new HashSet<Rekisterointi>();
            this.Puhelin1 = new HashSet<Puhelin>();
            this.Osoite1 = new HashSet<Osoite>();
            this.Varaus = new HashSet<Varaus>();
            this.Asiakkaat = new HashSet<Asiakkaat>();
        }
    
        public int Hoitaja_ID { get; set; }
        public string Tunnus { get; set; }
        public string Etunimi { get; set; }
        public string Toinen_nimi { get; set; }
        public string Sukunimi { get; set; }
        public string Katuosoite { get; set; }
        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
        public string Henkilotunnus { get; set; }
        public Nullable<System.DateTime> Aloituspvm { get; set; }
        public Nullable<System.DateTime> Valmistumispvm { get; set; }
        public Nullable<System.DateTime> Keskeytyspvm { get; set; }
        public string Tiedot_arkistoitu { get; set; }
        public Nullable<int> Huomio_ID { get; set; }
        public Nullable<int> Osoite_ID { get; set; }
        public Nullable<int> Puhelin_ID { get; set; }
        public Nullable<int> Kurssi_ID { get; set; }
        public Nullable<int> Rekisterointi_ID { get; set; }
        public Nullable<int> Palvelu_ID { get; set; }
        public Nullable<int> Asiakas_ID { get; set; }
        public Nullable<int> Varaus_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
        public virtual Huomiot Huomiot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Palvelut> Palvelut { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kurssi> Kurssi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rekisterointi> Rekisterointi { get; set; }
        public virtual Puhelin Puhelin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puhelin> Puhelin1 { get; set; }
        public virtual Osoite Osoite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osoite> Osoite1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varaus> Varaus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asiakkaat> Asiakkaat { get; set; }
        public virtual Asiakkaat Asiakkaat1 { get; set; }
        public virtual Varaus Varaus1 { get; set; }
        public virtual Palvelut Palvelut1 { get; set; }
    }
}
