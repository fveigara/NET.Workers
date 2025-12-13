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
            // Ejecutar SOLO si la BD está vacía
            if (db.Clientes.Any() || db.Actividades.Any())
                return;

            var rnd = new Random();

            // =====================================================
            // 1) ROLES
            // =====================================================
            var rolAdmin = new Rol { Nombre = "Administrador" };
            var rolCliente = new Rol { Nombre = "Cliente" };

            db.Roles.Add(rolAdmin);
            db.Roles.Add(rolCliente);
            db.SaveChanges();

            // =====================================================
            // 2) ACTIVIDADES (5)
            // =====================================================
            var actividades = new[]
            {
                new Actividad { Nombre = "Yoga", Intensidad = Intensidad.Baja,  Descripcion = "Relajación" },
                new Actividad { Nombre = "Pilates", Intensidad = Intensidad.Media, Descripcion = "Control postural" },
                new Actividad { Nombre = "CrossFit", Intensidad = Intensidad.Alta, Descripcion = "Alta intensidad" },
                new Actividad { Nombre = "Spinning", Intensidad = Intensidad.Alta, Descripcion = "Bicicleta indoor" },
                new Actividad { Nombre = "Zumba", Intensidad = Intensidad.Media, Descripcion = "Cardio y baile" }
            };

            db.Actividades.AddRange(actividades);
            db.SaveChanges();

            // =====================================================
            // 3) SESIONES (10)
            // =====================================================
            var actividadIds = db.Actividades.Select(a => a.Id).ToList();

            for (int i = 0; i < 10; i++)
            {
                db.Sesiones.Add(new Sesion
                {
                    ActividadId = actividadIds[rnd.Next(actividadIds.Count)],
                    FechaHora = DateTime.Now.Date.AddDays(rnd.Next(1, 14)).AddHours(rnd.Next(8, 21)),
                    Sala = "Sala " + rnd.Next(1, 4),
                    Monitor = "Monitor " + (char)('A' + rnd.Next(5)),
                    AforoMax = 16
                });
            }

            db.SaveChanges();

            // =====================================================
            // 4) CLIENTES (20)
            // =====================================================
            var clientes = new List<Cliente>();

            for (int i = 0; i < 20; i++)
            {
                clientes.Add(new Cliente
                {
                    Nombre = $"Cliente{i + 1}",
                    Apellidos = "Demo",
                    Documento = $"{10000000 + i}A",
                    Email = $"cliente{i + 1}@demo.com",
                    Telefono = "600000" + i.ToString("D2"),
                    FechaAlta = DateTime.Now.AddDays(-rnd.Next(1, 300)),
                    IsActive = true
                });
            }

            db.Clientes.AddRange(clientes);
            db.SaveChanges();

            // =====================================================
            // 5) ASIGNAR ROLES AUTOMÁTICOS
            // =====================================================
            foreach (var cliente in db.Clientes)
            {
                db.ClienteRoles.Add(new ClienteRol
                {
                    ClienteId = cliente.Id,
                    RolId = rolCliente.Id
                });
            }

            // Cliente admin
            var admin = new Cliente
            {
                Nombre = "Admin",
                Apellidos = "GenteFit",
                Documento = "00000000A",
                Email = "admin@gentefit.com",
                Telefono = "600000000",
                FechaAlta = DateTime.Now,
                IsActive = true
            };

            db.Clientes.Add(admin);
            db.SaveChanges();

            db.ClienteRoles.Add(new ClienteRol
            {
                ClienteId = admin.Id,
                RolId = rolAdmin.Id
            });

            db.SaveChanges();

            // =====================================================
            // 6) RESERVAS COHERENTES
            // =====================================================
            var sesiones = db.Sesiones.ToList();
            var clientesIds = db.Clientes.Select(c => c.Id).ToList();

            foreach (var ses in sesiones)
            {
                var clientesUsados = new HashSet<int>();

                int confirmadas = rnd.Next(0, ses.AforoMax + 1);
                int espera = rnd.Next(0, 5);

                // Confirmadas
                for (int i = 0; i < confirmadas; i++)
                {
                    int clienteId;
                    do
                    {
                        clienteId = clientesIds[rnd.Next(clientesIds.Count)];
                    }
                    while (!clientesUsados.Add(clienteId));

                    db.Reservas.Add(new Reserva
                    {
                        SesionId = ses.Id,
                        ClienteId = clienteId,
                        Estado = EstadoReserva.Confirmada,
                        CreatedAt = DateTime.Now.AddMinutes(-rnd.Next(0, 5000))
                    });
                }

                // Lista de espera SOLO si está lleno
                if (confirmadas >= ses.AforoMax)
                {
                    for (int i = 0; i < espera; i++)
                    {
                        int clienteId;
                        do
                        {
                            clienteId = clientesIds[rnd.Next(clientesIds.Count)];
                        }
                        while (!clientesUsados.Add(clienteId));

                        db.Reservas.Add(new Reserva
                        {
                            SesionId = ses.Id,
                            ClienteId = clienteId,
                            Estado = EstadoReserva.EnEspera,
                            PosicionEspera = i + 1,
                            CreatedAt = DateTime.Now.AddMinutes(-rnd.Next(0, 5000))
                        });
                    }
                }
            }

            db.SaveChanges();
        }
    }
}