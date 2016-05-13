using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointJalkahoitolaMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PointJalkahoitolaMVC.Database1
{
    public class JalkahoitolaContext : DbContext
    {
            public JalkahoitolaContext() : base ("JalkahoitolaContext")
        {
        }
        public DbSet<Asiakas>Asiakkaat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
