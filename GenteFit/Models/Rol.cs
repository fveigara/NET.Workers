using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Models
{
    public class Rol
    {
        public int Id { get; set; }

        // Nombre del rol (Administrador, Encargado, Recepcionista, Cliente)
        public string Nombre { get; set; }

        // Relación N-a-N con usuarios
        public virtual ICollection<ClienteRol> ClienteRoles { get; set; }
    }
}