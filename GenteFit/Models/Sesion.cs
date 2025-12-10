using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenteFit.Models
{
    public class Sesion
    {
        public const int CAPACITY_DEFAULT = 16;

        public int Id { get; set; }

        [Required] public int ActividadId { get; set; }
        public virtual Actividad Actividad { get; set; }

        public DateTime FechaHora { get; set; } // fecha + hora
        public string Sala { get; set; }
        public string Monitor { get; set; }
        public int AforoMax { get; set; } = CAPACITY_DEFAULT;

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}