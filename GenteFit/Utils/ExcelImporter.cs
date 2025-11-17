using ClosedXML.Excel;
using GenteFit.Models;
using System;
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

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);
                var rows = ws.RangeUsed().RowsUsed();

                bool first = true;
                foreach (var row in rows)
                {
                    if (first) { first = false; continue; } // Saltar cabecera

                    lista.Add(new Socio
                    {
                        Nombre = row.Cell(2).GetString(),
                        Email = row.Cell(3).GetString(),
                        FechaAlta = row.Cell(4).GetDateTime()
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
                        Precio = row.Cell(3).GetDecimal()
                    });
                }
            }

            return lista;
        }
    }
}
