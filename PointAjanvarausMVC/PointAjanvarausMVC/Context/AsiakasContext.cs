using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PointAjanvarausMVC.Models;


namespace PointAjanvarausMVC.Context
{
    public class AsiakasContext : DbContext
    {
        public DbSet <Asiakkaat> Asiakas{ get; set; }
    }
}
