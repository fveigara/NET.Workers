using GenteFit.DAO;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Controllers
{
    public class ClientesController
    {
        private readonly ClienteDAO dao = new ClienteDAO();

        public Cliente Registrar(string nombre, string apellidos, string documento, string email, string telefono)
        {
            var c = new Cliente
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Documento = documento,
                Email = email,
                Telefono = telefono,
                IsActive = true
            };
            return dao.Insert(c);
        }

        public void Editar(int id, string nombre, string apellidos, string documento, string email, string telefono)
        {
            dao.Update(new Cliente { Id = id, Nombre = nombre, Apellidos = apellidos, Documento = documento, Email = email, Telefono = telefono });
        }

        public void Bajar(int id)
        {
            dao.Deactivate(id);
        }

        public List<Cliente> Buscar(string query) => dao.SearchByNameOrDocumento(query);

        public List<Cliente> Listar() => dao.GetAllActive();

        public Cliente GetById(int id) => dao.GetById(id);
    }
}