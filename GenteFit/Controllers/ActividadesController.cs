using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.DAO;
using GenteFit.Models;

namespace GenteFit.Controllers
{
    public class ActividadesController
    {
        private readonly ActividadDAO dao = new ActividadDAO();

        public Actividad Crear(string nombre, string descripcion, Intensidad intensidad)
        {
            return dao.Insert(new Actividad { Nombre = nombre, Descripcion = descripcion, Intensidad = intensidad });
        }

        public void Editar(int id, string nombre, string descripcion, Intensidad intensidad)
        {
            dao.Update(new Actividad { Id = id, Nombre = nombre, Descripcion = descripcion, Intensidad = intensidad });
        }

        public void Baja(int id) => dao.Delete(id);

        public List<Actividad> Listar() => dao.GetAll();
    }
}