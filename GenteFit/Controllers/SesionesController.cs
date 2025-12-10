using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.DAO;
using GenteFit.Models;

namespace GenteFit.Controllers
{
    public class SesionesController
    {
        private readonly SesionDAO dao = new SesionDAO();

        public Sesion Programar(int actividadId, DateTime fechaHora, string sala, string monitor, int aforo = Sesion.CAPACITY_DEFAULT)
        {
            return dao.Insert(new Sesion { ActividadId = actividadId, FechaHora = fechaHora, Sala = sala, Monitor = monitor, AforoMax = aforo });
        }

        public void Editar(Sesion s) => dao.Update(s);

        public List<Sesion> ListarProximas() => dao.ListUpcoming();
        public Sesion GetById(int id) => dao.GetById(id);
    }
}