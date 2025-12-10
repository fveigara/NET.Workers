using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenteFit.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(20)]
        public string Documento { get; set; } // DNI / NIF

        [EmailAddress] public string Email { get; set; }
        public string Telefono { get; set; }

        public bool IsActive { get; set; } = true; // soft delete

        // navegación
        public virtual ICollection<Reserva> Reservas { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}