using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GenteFit.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GenteFit.Data.GenteFitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GenteFit.Data.GenteFitContext context)
        {
            //
            // Este metodo sera llamado tras la migracion a la ultima version.
            // Puedes usar el metodo de extension DbSet<T>.AddOrUpdate()
            // para ayudar a evitar crear datos de semilla duplicados.
            //
        }
    }
}
