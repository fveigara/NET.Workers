using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Models;

namespace GenteFit.Data
{
    public static class SeedData
    {
        public static void Initialize(GenteFitContext db)
        {
            // Se ejecuta solo si la base está completamente vacía.
            if (db.Actividades.Any() || db.Clientes.Any() || db.Sesiones.Any() || db.Reservas.Any())
                return;

            // ================================
            // 1) ACTIVIDADES (5)
            // ================================
            var actividades = new Actividad[]
            {
                new Actividad { Nombre = "Yoga",            Descripcion = "Relajación y respiración", Intensidad = Intensidad.Baja },
                new Actividad { Nombre = "Pilates",         Descripcion = "Control postural",         Intensidad = Intensidad.Media },
                new Actividad { Nombre = "CrossFit",        Descripcion = "Alta intensidad",          Intensidad = Intensidad.Alta },
                new Actividad { Nombre = "Spinning",        Descripcion = "Bicicleta indoor",         Intensidad = Intensidad.Alta },
                new Actividad { Nombre = "Zumba",           Descripcion = "Cardio y baile",           Intensidad = Intensidad.Media },
            };

            db.Actividades.AddRange(actividades);
            db.SaveChanges();


            // ================================
            // 2) SESIONES (10)
            // ================================
            var actividadIds = db.Actividades.Select(a => a.Id).ToList();
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var actId = actividadIds[rnd.Next(actividadIds.Count)];

                var fecha = DateTime.Now.Date.AddDays(rnd.Next(1, 15))  // entre mañana y 15 días
                                             .AddHours(rnd.Next(8, 21)); // de 8h a 20h

                var ses = new Sesion
                {
                    ActividadId = actId,
                    FechaHora = fecha,
                    Sala = "Sala " + rnd.Next(1, 4),
                    Monitor = "Monitor " + (char)('A' + rnd.Next(5)),
                    AforoMax = rnd.Next(10, 25)
                };

                db.Sesiones.Add(ses);
            }

            db.SaveChanges();


            // ================================
            // 3) CLIENTES (20)
            // ================================
            var clientes = new Cliente[20];
            for (int i = 0; i < 20; i++)
            {
                clientes[i] = new Cliente
                {
                    Nombre = "Cliente" + (i + 1),
                    Apellidos = "Demo",
                    Documento = $"{10000000 + i}A",
                    Email = $"cliente{i + 1}@demo.com",
                    Telefono = "600000" + i.ToString().PadLeft(2, '0'),
                    FechaAlta = DateTime.Now.AddDays(-rnd.Next(0, 365)),
                    IsActive = true
                };
            }

            db.Clientes.AddRange(clientes);
            db.SaveChanges();


            // ================================
            // 4) RESERVAS DEMO (opcionales)
            // - Añadimos algunas reservas aleatorias sin romper aforo
            // ================================
            var sesiones = db.Sesiones.ToList();
            var clientesIds = db.Clientes.Select(c => c.Id).ToList();

            foreach (var ses in sesiones)
            {
                int plazasConfirmadas = rnd.Next(0, ses.AforoMax);
                int plazasEspera = rnd.Next(0, 3);

                // Confirmadas
                for (int i = 0; i < plazasConfirmadas; i++)
                {
                    int cliId = clientesIds[rnd.Next(clientesIds.Count)];
                    db.Reservas.Add(new Reserva
                    {
                        SesionId = ses.Id,
                        ClienteId = cliId,
                        Estado = EstadoReserva.Confirmada,
                        CreatedAt = DateTime.Now.AddMinutes(-rnd.Next(0, 10000))
                    });
                }

                // Lista de espera
                for (int i = 0; i < plazasEspera; i++)
                {
                    int cliId = clientesIds[rnd.Next(clientesIds.Count)];
                    db.Reservas.Add(new Reserva
                    {
                        SesionId = ses.Id,
                        ClienteId = cliId,
                        Estado = EstadoReserva.EnEspera,
                        PosicionEspera = i + 1,
                        CreatedAt = DateTime.Now.AddMinutes(-rnd.Next(0, 10000))
                    });
                }
            }

            db.SaveChanges();
        }
    }
}