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
    internal static class Program
    {
        static void Main()
        {
            // 🔹 Obtener la ruta base del proyecto (tres niveles arriba de bin\Debug)
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaXmlImport = System.IO.Path.Combine(rutaBase, @"..\..\..\Xml\socios.xml");
            string rutaXmlExport = System.IO.Path.Combine(rutaBase, @"..\..\..\Xml\socios_exportados.xml");

            using (var db = new GenteFitContext())
            {
                // --- ALTA ---
                var s1 = new Socio { Nombre = "Nuevo Socio", Email = "nuevo@socio.com", FechaAlta = DateTime.Now };
                db.Socios.Add(s1);
                db.SaveChanges();
                Console.WriteLine($"Alta de socio Id={s1.Id}");

                // --- CONSULTA ---
                var socios = db.Socios.ToList();
                Console.WriteLine($"Socios en BD: {socios.Count}");

                // --- MODIFICACIÓN ---
                var socio = db.Socios.First();
                socio.Email = "modificado@socio.com";
                db.SaveChanges();
                Console.WriteLine("Email actualizado");

                // --- BAJA ---
                db.Socios.Remove(socio);
                db.SaveChanges();
                Console.WriteLine("Socio eliminado");

                // --- IMPORTAR XML ---
                XmlHandler.ImportarSociosDesdeXml(rutaXmlImport);
                Console.WriteLine("Socios importados desde XML.");

                // --- EXPORTAR XML ---
                XmlHandler.ExportarSociosAXml(rutaXmlExport);
                Console.WriteLine("Socios exportados a XML.");
            }

            Console.WriteLine("\nEjecución completa en .NET Framework 4.8");
            Console.WriteLine("Presiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
