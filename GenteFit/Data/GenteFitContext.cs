using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Models;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace GenteFit.Data
{
    public class GenteFitContext : DbContext
    {
        public GenteFitContext() : base("name=GenteFitDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GenteFitContext>());
        }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }

}
