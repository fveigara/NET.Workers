using GenteFit.Data;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.DAO
{
    public class ClienteDAO
    {
        public Cliente Insert(Cliente c)
        {
            using (var db = new GenteFitContext())
            {
                db.Clientes.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public void Update(Cliente c)
        {
            using (var db = new GenteFitContext())
            {
                var old = db.Clientes.Find(c.Id);
                if (old == null) return;
                old.Nombre = c.Nombre;
                old.Apellidos = c.Apellidos;
                old.Documento = c.Documento;
                old.Email = c.Email;
                old.Telefono = c.Telefono;
                db.SaveChanges();
            }
        }

        // soft delete
        public void Deactivate(int id)
        {
            using (var db = new GenteFitContext())
            {
                var c = db.Clientes.Find(id);
                if (c == null) return;
                c.IsActive = false;
                db.SaveChanges();
            }
        }

        public Cliente GetById(int id)
        {
            using (var db = new GenteFitContext())
                return db.Clientes.Find(id);
        }

        public List<Cliente> SearchByNameOrDocumento(string query)
        {
            using (var db = new GenteFitContext())
            {
                var q = query?.ToLower() ?? "";
                return db.Clientes
                    .Where(x => x.IsActive && (x.Nombre.ToLower().Contains(q) || x.Apellidos.ToLower().Contains(q) || x.Documento.ToLower().Contains(q)))
                    .ToList();
            }
        }

        public List<Cliente> GetAllActive()
        {
            using (var db = new GenteFitContext())
                return db.Clientes.Where(x => x.IsActive).ToList();
        }
    }
}