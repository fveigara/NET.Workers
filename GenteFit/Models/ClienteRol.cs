using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenteFit.Models
{
    public class ClienteRol
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}