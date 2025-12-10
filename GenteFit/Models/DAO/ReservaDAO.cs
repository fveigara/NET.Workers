using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Data;
using GenteFit.Models;

namespace GenteFit.DAO
{
    public class ReservaDAO
    {
        // Reserva: intenta confirmar, si no, añade en lista de espera
        public Reserva MakeReservation(int clienteId, int sesionId)
        {
            using (var db = new GenteFitContext())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var sesion = db.Sesiones.Find(sesionId);
                    if (sesion == null) throw new Exception("Sesión no encontrada.");

                    // número de reservas confirmadas activas (no anuladas)
                    var confirmedCount = db.Reservas.Count(r => r.SesionId == sesionId && r.Estado == EstadoReserva.Confirmada);

                    Reserva nueva = new Reserva
                    {
                        ClienteId = clienteId,
                        SesionId = sesionId,
                        CreatedAt = DateTime.UtcNow
                    };

                    if (confirmedCount < sesion.AforoMax)
                    {
                        nueva.Estado = EstadoReserva.Confirmada;
                        nueva.PosicionEspera = null;
                    }
                    else
                    {
                        // posición = max(posicion) + 1
                        var maxPos = db.Reservas.Where(r => r.SesionId == sesionId && r.Estado == EstadoReserva.EnEspera)
                                                 .Select(r => (int?)r.PosicionEspera).Max() ?? 0;
                        nueva.Estado = EstadoReserva.EnEspera;
                        nueva.PosicionEspera = maxPos + 1;
                    }

                    db.Reservas.Add(nueva);
                    db.SaveChanges();
                    tx.Commit();
                    return nueva;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // Cancelar reserva del cliente en una sesión
        public void CancelReservation(int clienteId, int sesionId)
        {
            using (var db = new GenteFitContext())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var reserva = db.Reservas.FirstOrDefault(r => r.ClienteId == clienteId && r.SesionId == sesionId && r.Estado != EstadoReserva.Anulada);
                    if (reserva == null) return;

                    reserva.Estado = EstadoReserva.Anulada;
                    reserva.PosicionEspera = null;
                    db.SaveChanges();

                    // Si la reserva cancelada era Confirmada -> promover primer en espera
                    if (reserva.Estado == EstadoReserva.Anulada)
                    {
                        // find first waiting (posicion 1)
                        var firstWaiting = db.Reservas
                            .Where(r => r.SesionId == sesionId && r.Estado == EstadoReserva.EnEspera)
                            .OrderBy(r => r.PosicionEspera)
                            .FirstOrDefault();

                        if (firstWaiting != null)
                        {
                            firstWaiting.Estado = EstadoReserva.Confirmada;
                            firstWaiting.PosicionEspera = null;
                            db.SaveChanges();

                            // recalcular posiciones de espera (decrementar posiciones)
                            var waitlist = db.Reservas
                                .Where(r => r.SesionId == sesionId && r.Estado == EstadoReserva.EnEspera)
                                .OrderBy(r => r.PosicionEspera)
                                .ToList();

                            int pos = 1;
                            foreach (var w in waitlist)
                            {
                                w.PosicionEspera = pos++;
                            }
                            db.SaveChanges();
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public List<Reserva> GetReservationsByCliente(int clienteId)
        {
            using (var db = new GenteFitContext())
            {
                return db.Reservas.Where(r => r.ClienteId == clienteId).ToList();
            }
        }

        public (List<Reserva> confirmed, List<Reserva> waiting) GetReservationsBySesion(int sesionId)
        {
            using (var db = new GenteFitContext())
            {
                var confirmed = db.Reservas.Where(r => r.SesionId == sesionId && r.Estado == EstadoReserva.Confirmada).ToList();
                var waiting = db.Reservas.Where(r => r.SesionId == sesionId && r.Estado == EstadoReserva.EnEspera).OrderBy(r => r.PosicionEspera).ToList();
                return (confirmed, waiting);
            }
        }
    }
}