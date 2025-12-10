using ClosedXML.Excel;
using GenteFit.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Utils
{
    public static class ExcelImporter
    {
        public static List<Cliente> ImportClientes(string filePath)
        {
            var lista = new List<Cliente>();
            string[] candidates = {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel", "clientes.xlsx"),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Excel\\clientes.xlsx"))
            };
            string found = candidates.FirstOrDefault(File.Exists);
            if (found == null)
            {
                // registrar y/o pedir al usuario seleccionar el fichero
                throw new FileNotFoundException($"No se encontró el fichero Excel. Buscados: {string.Join(", ", candidates)}");
            }

            using (var wb = new XLWorkbook(found))
            {
                var ws = wb.Worksheet(1);
                if (ws == null || ws.IsEmpty())
                    return lista; // no hay datos

                var rows = ws.RowsUsed(); // seguro aunque la hoja esté vacía devuelve colección vacía
                bool first = true;
                foreach (var row in rows)
                {
                    if (first) { first = false; continue; } // saltar header si aplica

                    var nombre = row.Cell(2).GetString();
                    var apellidos = row.Cell(3).GetString();
                    var documento = row.Cell(4).GetString();
                    var email = row.Cell(5).GetString();
                    var telefono = row.Cell(6).GetString();

                    DateTime fechaAlta;
                    if (!row.Cell(7).TryGetValue(out fechaAlta))
                        fechaAlta = DateTime.MinValue; // o nullables según modelo

                    lista.Add(new Cliente
                    {
                        Nombre = nombre,
                        Apellidos = apellidos,
                        Documento = documento,
                        Email = email,
                        Telefono = telefono,
                        FechaAlta = fechaAlta
                    });
                }
            }
            return lista;
        }

        public static List<Producto> ImportProductos(string filePath)
        {
            var lista = new List<Producto>();

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);
                var rows = ws.RangeUsed().RowsUsed();

                bool first = true;
                foreach (var row in rows)
                {
                    if (first) { first = false; continue; }

                    lista.Add(new Producto
                    {
                        Nombre = row.Cell(2).GetString(),
                        Precio = Convert.ToDecimal(row.Cell(3).Value)
                    });
                }
            }

            return lista;
        }
    }
}
