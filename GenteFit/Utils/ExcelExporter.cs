using ClosedXML.Excel;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Utils
{
    public static class ExcelExporter
    {
        public static void ExportClientes(string filePath, List<Cliente> clientes)
        {
            EnsureDirectoryExists(filePath);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Clientes");

                // Cabecera
                ws.Cell(1, 1).Value = "Id";
                ws.Cell(1, 2).Value = "Nombre";
                ws.Cell(1, 3).Value = "Apellidos";
                ws.Cell(1, 4).Value = "Documento";
                ws.Cell(1, 5).Value = "Email";
                ws.Cell(1, 6).Value = "Teléfono";
                ws.Cell(1, 7).Value = "Fecha Alta";
                
                // Datos
                int r = 2;
                foreach (var c in clientes)
                {
                    ws.Cell(r, 1).Value = c.Id;
                    ws.Cell(r, 2).Value = c.Nombre;
                    ws.Cell(r, 3).Value = c.Apellidos;
                    ws.Cell(r, 4).Value = c.Documento;
                    ws.Cell(r, 5).Value = c.Email;
                    ws.Cell(r, 6).Value = c.Telefono;
                    ws.Cell(r, 7).Value = c.FechaAlta;
                    ws.Cell(r, 7).Style.DateFormat.Format = "dd/MM/yyyy";
                    r++;
                }

                // Formato
                var headerRange = ws.Range(1, 1, 1, 7);
                headerRange.Style.Font.SetBold();
                ws.RangeUsed().SetAutoFilter();
                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);

            }
        }

        public static void ExportProductos(string filePath, List<Producto> productos)
        {
            EnsureDirectoryExists(filePath);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Productos");

                // Cabecera
                ws.Cell(1, 1).Value = "Id";
                ws.Cell(1, 2).Value = "Nombre";
                ws.Cell(1, 3).Value = "Precio";

                // Datos
                int r = 2;
                foreach (var p in productos)
                {
                    ws.Cell(r, 1).Value = p.Id;
                    ws.Cell(r, 2).Value = p.Nombre;
                    ws.Cell(r, 3).Value = p.Precio;
                    ws.Cell(r, 3).Style.NumberFormat.Format = "#,##0.00";
                    r++;
                }

                // Formato
                var headerRange = ws.Range(1, 1, 1, 3);
                headerRange.Style.Font.SetBold();
                ws.RangeUsed().SetAutoFilter();
                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);
            }
        }

        private static void EnsureDirectoryExists(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
    }
}
