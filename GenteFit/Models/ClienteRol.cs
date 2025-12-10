using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Models
{
    public class ClienteRol
    {
        // ID de unión
        public int Id { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

