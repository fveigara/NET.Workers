using GenteFit.DAO;
using GenteFit.Data;
using GenteFit.Models;
using GenteFit.Models.DTO;
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

        public void Registrar(string nombre, string apellidos, string documento, string email, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre obligatorio");

            if (string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("Documento obligatorio");

            if (documento.Length > 20)
                throw new ArgumentException("Documento demasiado largo");

            using (var db = new GenteFitContext())
            {
                var cliente = new Cliente
                {
                    Nombre = nombre.Trim(),
                    Apellidos = apellidos?.Trim(),
                    Documento = documento.Trim(),
                    Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim(),
                    Telefono = telefono?.Trim(),
                    FechaAlta = DateTime.Now,
                    IsActive = true
                };

                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }


        public void Editar(int id, string nombre, string apellidos, string documento, string email, string telefono)
        {
            dao.Update(new Cliente { Id = id, Nombre = nombre, Apellidos = apellidos, Documento = documento, Email = email, Telefono = telefono });
        }

        public void Bajar(int id)
        {
            dao.Deactivate(id);
        }

        public List<ClienteDTO> Buscar(string filtro)
        {
            using (var db = new GenteFitContext())
            {
                return db.Clientes
                    .Where(c => c.Nombre.Contains(filtro))
                    .Select(c => new ClienteDTO
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Apellidos = c.Apellidos,
                        Documento = c.Documento,
                        Email = c.Email,
                        Telefono = c.Telefono,
                        FechaAlta = c.FechaAlta,
                        IsActive = c.IsActive
                    })
                    .ToList();
            }
        }


        public List<Cliente> Listar() => dao.GetAllActive();

        public Cliente GetById(int id) => dao.GetById(id);
    }
}