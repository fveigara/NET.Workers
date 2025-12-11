using GenteFit.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GenteFit.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GenteFit.Data.GenteFitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GenteFit.Data.GenteFitContext context)
        {
            // No insertar datos aquí.
            // TODO: Semilla movida a SeedData.Initialize(context).
        }
    }
}