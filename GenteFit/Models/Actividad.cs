using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenteFit.Models
{
    public enum Intensidad
    {
        Baja,
        Media,
        Alta
    }

    public class Actividad
    {
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Intensidad Intensidad { get; set; }

        public virtual ICollection<Sesion> Sesiones { get; set; }
    }
}