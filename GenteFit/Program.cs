using GenteFit;
using GenteFit.Data;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace GenteFit
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ejecutar seed una vez
            using (var db = new GenteFitContext())
            {
                SeedData.Initialize(db);
            }

            Application.Run(new Form1());
        }

        private static void EjecutarPruebasBD()
        {
            using (var db = new GenteFitContext())
            {
                try
                {
                    // 1) ACTIVIDADES DEMO
                    var act1 = new Actividad
                    {
                        Nombre = "Yoga",
                        Descripcion = "Relajación",
                        Intensidad = Intensidad.Baja
                    };
                    var act2 = new Actividad
                    {
                        Nombre = "Crossfit",
                        Descripcion = "Alta intensidad",
                        Intensidad = Intensidad.Alta
                    };

                    db.Actividades.Add(act1);
                    db.Actividades.Add(act2);
                    db.SaveChanges(); // necesario para generar IDs


                    // 2) SESIONES DEMO (requieren FK válida ActividadId)
                    var ses1 = new Sesion
                    {
                        ActividadId = act1.Id,
                        FechaHora = DateTime.Now.AddDays(1).Date.AddHours(10),
                        Sala = "Sala 1",
                        Monitor = "Laura",
                        AforoMax = 16
                    };
                    var ses2 = new Sesion
                    {
                        ActividadId = act2.Id,
                        FechaHora = DateTime.Now.AddDays(2).Date.AddHours(18),
                        Sala = "Sala 2",
                        Monitor = "Pedro",
                        AforoMax = 20
                    };

                    db.Sesiones.Add(ses1);
                    db.Sesiones.Add(ses2);
                    db.SaveChanges();


                    // 3) CLIENTES DEMO
                    var cli1 = new Cliente
                    {
                        Nombre = "Carlos",
                        Apellidos = "Pérez",
                        Documento = "11111111A",
                        Email = "carlos@test.com",
                        Telefono = "600000001",
                        FechaAlta = DateTime.Now
                    };
                    var cli2 = new Cliente
                    {
                        Nombre = "Ana",
                        Apellidos = "Gómez",
                        Documento = "22222222B",
                        Email = "ana@test.com",
                        Telefono = "600000002",
                        FechaAlta = DateTime.Now
                    };

                    db.Clientes.Add(cli1);
                    db.Clientes.Add(cli2);
                    db.SaveChanges();


                    // 4) RESERVAS DEMO (requieren ClienteId + SesionId válidos)
                    var r1 = new Reserva
                    {
                        ClienteId = cli1.Id,
                        SesionId = ses1.Id,
                        Estado = EstadoReserva.Confirmada,
                        CreatedAt = DateTime.Now
                    };

                    var r2 = new Reserva
                    {
                        ClienteId = cli2.Id,
                        SesionId = ses1.Id,
                        Estado = EstadoReserva.EnEspera,
                        PosicionEspera = 1,
                        CreatedAt = DateTime.Now
                    };

                    db.Reservas.Add(r1);
                    db.Reservas.Add(r2);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine($"Entidad: {eve.Entry.Entity.GetType().Name}");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine($"  Propiedad: {ve.PropertyName} — Error: {ve.ErrorMessage}");
                        }
                    }
                    throw;
                }
            }
        }
    }
}