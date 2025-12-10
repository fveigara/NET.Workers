using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.DAO;
using GenteFit.Models;

namespace GenteFit.Controllers
{
    public class ReservasController
    {
        private readonly ReservaDAO dao = new ReservaDAO();

        public Reserva Reservar(int clienteId, int sesionId)
        {
            return dao.MakeReservation(clienteId, sesionId);
        }

        public void AnularReserva(int clienteId, int sesionId)
        {
            dao.CancelReservation(clienteId, sesionId);
        }

        public List<Reserva> ReservasDeCliente(int clienteId) => dao.GetReservationsByCliente(clienteId);

        public (List<Reserva> confirmed, List<Reserva> waiting) EstadoDeSesion(int sesionId) => dao.GetReservationsBySesion(sesionId);
    }
}