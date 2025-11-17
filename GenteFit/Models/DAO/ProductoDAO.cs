using GenteFit.Data;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.DAO
{
    public class ProductoDAO
    {
        public List<Producto> GetAll()
        {
            using (var db = new GenteFitContext())
                return db.Productos.ToList();
        }

        public Producto GetById(int id)
        {
            using (var db = new GenteFitContext())
                return db.Productos.Find(id);
        }

        public void Insert(Producto producto)
        {
            using (var db = new GenteFitContext())
            {
                db.Productos.Add(producto);
                db.SaveChanges();
            }
        }

        public void Update(Producto producto)
        {
            using (var db = new GenteFitContext())
            {
                var p = db.Productos.Find(producto.Id);
                if (p == null) return;

                p.Nombre = producto.Nombre;
                p.Precio = producto.Precio;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new GenteFitContext())
            {
                var p = db.Productos.Find(id);
                if (p == null) return;
                db.Productos.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
