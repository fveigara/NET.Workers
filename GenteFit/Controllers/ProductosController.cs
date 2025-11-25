using GenteFit.DAO;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Controllers
{
    public class ProductosController
    {
        private readonly ProductoDAO dao = new ProductoDAO();

        public List<Producto> Listar() => dao.GetAll();

        public void Alta(string nombre, decimal precio)
        {
            dao.Insert(new Producto
            {
                Nombre = nombre,
                Precio = precio
            });
        }

        public void Modificar(int id, string nombre, decimal precio)
        {
            dao.Update(new Producto
            {
                Id = id,
                Nombre = nombre,
                Precio = precio
            });
        }

        public void Baja(int id) => dao.Delete(id);
    }
}
