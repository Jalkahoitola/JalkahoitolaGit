﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JohaMeriSQL1Entities1 : DbContext
    {
        public JohaMeriSQL1Entities1()
            : base("name=JohaMeriSQL1Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asiakkaat> Asiakkaat { get; set; }
        public virtual DbSet<Hoitajat> Hoitajat { get; set; }
        public virtual DbSet<Postitoimipaikat1> Postitoimipaikat1 { get; set; }
        public virtual DbSet<Puhelintiedot> Puhelintiedot { get; set; }
        public virtual DbSet<Toimipisteet> Toimipisteet { get; set; }
        public virtual DbSet<Varauskalenteri> Varauskalenteri { get; set; }
        public virtual DbSet<Palvelut> Palvelut { get; set; }
        public virtual DbSet<Rekisterointi> Rekisterointi { get; set; }
        public virtual DbSet<Kurssit> Kurssit { get; set; }
    }
}
