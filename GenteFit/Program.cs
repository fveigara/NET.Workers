using GenteFit;
using GenteFit.Data;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFit
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Substituir "using var db = new GenteFitContext();" por el patrón clásico try-finally/dispose
            GenteFitContext db = null;
            try
            {
                db = new GenteFitContext();

                // ALTA
                var c1 = new Cliente { Nombre = "Nuevo Cliente", Email = "nuevo@cliente.com", FechaAlta = DateTime.Now };
                db.Clientes.Add(c1);
                db.SaveChanges();
                Console.WriteLine($"Alta Cliente Id={c1.Id}");

                // CONSULTA
                var clientes = db.Clientes.ToList();
                Console.WriteLine($"Clientes en BD: {clientes.Count}");

                // MODIFICACION
                var cliente = db.Clientes.First();
                cliente.Email = "modificado@cliente.com";
                db.SaveChanges();
                Console.WriteLine("Email actualizado");

                // BAJA
                db.Clientes.Remove(cliente);
                db.SaveChanges();
                Console.WriteLine("Cliente eliminado");

                // IMPORTAR Excel
                Utils.ExcelImporter.ImportClientes("Excel/clientes.xlsx");

                // EXPORTAR Excel
                Utils.ExcelExporter.ExportClientes("Excel/clientes_exportados.xlsx", clientes);

                Console.WriteLine("Demo completa en .NET 4.8");
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }
    }
}