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
            // Sustituir "using var db = new GenteFitContext();" por el patrón clásico try-finally/dispose
            GenteFitContext db = null;
            try
            {
                db = new GenteFitContext();

                // ALTA
                var s1 = new Socio { Nombre = "Nuevo Socio", Email = "nuevo@socio.com", FechaAlta = DateTime.Now };
                db.Socios.Add(s1);
                db.SaveChanges();
                Console.WriteLine($"Alta Socio Id={s1.Id}");

                // CONSULTA
                var socios = db.Socios.ToList();
                Console.WriteLine($"Socios en BD: {socios.Count}");

                // MODIFICACION
                var socio = db.Socios.First();
                socio.Email = "modificado@socio.com";
                db.SaveChanges();
                Console.WriteLine("Email actualizado");

                // BAJA
                db.Socios.Remove(socio);
                db.SaveChanges();
                Console.WriteLine("Socio eliminado");

                // IMPORTAR XML
                XmlHandler.ImportarSociosDesdeXml("Xml/socios.xml");

                // EXPORTAR XML
                XmlHandler.ExportarSociosAXml("Xml/socios_salida.xml");

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