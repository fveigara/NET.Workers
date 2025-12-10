using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenteFit.Models
{
    public enum EstadoReserva
    {
        Confirmada,
        EnEspera,
        Anulada
    }

    public class Reserva
    {
        public int Id { get; set; }

        [Required] public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required] public int SesionId { get; set; }
        public virtual Sesion Sesion { get; set; }

        public EstadoReserva Estado { get; set; }
        public int? PosicionEspera { get; set; } // si está en espera, su posición (1..n). null cuando confirmada o anulada

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}