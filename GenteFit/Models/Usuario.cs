using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenteFit.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        // Datos principales del usuario
        public string NombreUsuario { get; set; }     // login (username)
        public string Email { get; set; }

        // Seguridad
        public string PasswordHash { get; set; }      // contraseña hasheada
        public string Salt { get; set; }              // salt por usuario

        // Relación N-a-N con roles
        public virtual ICollection<ClienteRol> ClienteRoles { get; set; }
    }
}
