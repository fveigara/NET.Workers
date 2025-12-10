using GenteFit.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GenteFit.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GenteFit.Data.GenteFitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // opcional pero recomendable en desarrollo
        }


        protected override void Seed(GenteFit.Data.GenteFitContext context)
        {
            //
            // Este método se ejecuta automáticamente después de aplicar una migración.
            // Sirve para insertar datos iniciales sin duplicarlos.
            //

            // -------------------------------
            // ROLES DEL SISTEMA
            // -------------------------------
            context.Roles.AddOrUpdate(
                r => r.Nombre,
                new Models.Rol { Nombre = "Administrador" },
                new Models.Rol { Nombre = "Encargado" },
                new Models.Rol { Nombre = "Recepcionista" },
                new Models.Rol { Nombre = "Cliente" }
            );

            // -------------------------------
            // ACTIVIDADES BASE
            // -------------------------------
            context.Actividades.AddOrUpdate(
                a => a.Nombre,
                new Models.Actividad { Nombre = "Zumba", Intensidad = Intensidad.Alta, Descripcion = "Actividad de cardio" },
                new Models.Actividad { Nombre = "Yoga", Intensidad = Intensidad.Baja, Descripcion = "Entrenamiento de equilibrio y respiración" },
                new Models.Actividad { Nombre = "Spinning", Intensidad = Intensidad.Alta, Descripcion = "Bicicleta indoor" }
            );

            // -------------------------------
            // CLIENTE DEMO
            // -------------------------------
            context.Clientes.AddOrUpdate(
                c => c.Email,
                new Models.Cliente
                {
                    Nombre = "Admin",
                    Apellidos = "GenteFit",
                    Documento = "00000000A",
                    Email = "admin@gentefit.com",
                    Telefono = "600000000",
                    FechaAlta = DateTime.Now,
                    IsActive = true
                }
            );

            context.SaveChanges();
        }
    }
}