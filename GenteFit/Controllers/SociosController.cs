using GenteFit.DAO;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Controllers
{
    public class SociosController
    {
        private readonly SocioDAO dao = new SocioDAO();

        public List<Socio> Listar() => dao.GetAll();

        public void Alta(string nombre, string email)
        {
            dao.Insert(new Socio
            {
                Nombre = nombre,
                Email = email,
                FechaAlta = System.DateTime.Now
            });
        }

        public void Modificar(int id, string nombre, string email)
        {
            dao.Update(new Socio
            {
                Id = id,
                Nombre = nombre,
                Email = email
            });
        }

        public void Baja(int id) => dao.Delete(id);
    }
}
