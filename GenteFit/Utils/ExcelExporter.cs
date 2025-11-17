using ClosedXML.Excel;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.Utils
{
    public static class ExcelExporter
    {
        public static void ExportSocios(string filePath, List<Socio> socios)
        {
            EnsureDirectoryExists(filePath);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Socios");

                // Cabecera
                ws.Cell(1, 1).Value = "Id";
                ws.Cell(1, 2).Value = "Nombre";
                ws.Cell(1, 3).Value = "Email";
                ws.Cell(1, 4).Value = "FechaAlta";

                // Datos
                int r = 2;
                foreach (var s in socios)
                {
                    ws.Cell(r, 1).Value = s.Id;
                    ws.Cell(r, 2).Value = s.Nombre;
                    ws.Cell(r, 3).Value = s.Email;
                    ws.Cell(r, 4).Value = s.FechaAlta;
                    ws.Cell(r, 4).Style.NumberFormat.Format = "yyyy-mm-dd hh:mm:ss";
                    r++;
                }

                // Formato: negrita cabecera, auto-ajustar columnas, filtro
                var headerRange = ws.Range(1, 1, 1, 4);
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
