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
            // IMPORTANTÍSIMO:
            // Usar migraciones de Entity Framework para controlar el esquema.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GenteFitContext, GenteFit.Migrations.Configuration>());
        }

        // ENTIDADES PRINCIPALES
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        // USUARIOS Y ROLES
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<ClienteRol> ClienteRoles { get; set; }
    }
}