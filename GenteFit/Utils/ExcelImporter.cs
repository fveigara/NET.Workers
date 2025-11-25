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
        public static List<Socio> ImportSocios(string filePath)
        {
            var lista = new List<Socio>();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.GetFullPath(Path.Combine(baseDir, filePath));

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"No se encontró el fichero Excel: {fullPath}");

            using (var wb = new XLWorkbook(fullPath))
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
                    var email = row.Cell(3).GetString();

                    DateTime fechaAlta;
                    if (!row.Cell(4).TryGetValue(out fechaAlta))
                        fechaAlta = DateTime.MinValue; // o nullables según modelo

                    lista.Add(new Socio
                    {
                        Nombre = nombre,
                        Email = email,
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
