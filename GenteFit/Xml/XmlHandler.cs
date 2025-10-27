using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using GenteFit.Data;
using GenteFit.Models;

namespace GenteFit
{
    public static class XmlHandler
    {
        public static void ImportarSociosDesdeXml(string rutaXml)
        {
            if (!System.IO.File.Exists(rutaXml))
            {
                Console.WriteLine($"No se encontró el archivo XML en la ruta: {rutaXml}");
                return;
            }

            var doc = XDocument.Load(rutaXml);

            using (var db = new GenteFitContext())
            {
                foreach (var x in doc.Root.Elements("Socio"))
                {
                    var socio = new Socio
                    {
                        Nombre = (string)x.Element("Nombre"),
                        Email = (string)x.Element("Email"),
                        FechaAlta = DateTime.Parse((string)x.Element("FechaAlta"), CultureInfo.InvariantCulture)
                    };

                    db.Socios.Add(socio);
                }

                db.SaveChanges();
            }

            Console.WriteLine("Socios importados correctamente desde XML.");
        }

        public static void ExportarSociosAXml(string rutaSalida)
        {
            using (var db = new GenteFitContext())
            {
                // 🔹 Cargar los socios desde la base de datos
                var listaSocios = db.Socios.AsEnumerable().ToList();
                Console.WriteLine($"Socios encontrados en la BD: {listaSocios.Count}");

                if (listaSocios.Count == 0)
                {
                    Console.WriteLine("No hay socios en la base de datos para exportar.");
                    return;
                }

                // 🔹 Crear la carpeta si no existe
                var directorio = System.IO.Path.GetDirectoryName(rutaSalida);
                if (!System.IO.Directory.Exists(directorio))
                {
                    System.IO.Directory.CreateDirectory(directorio);
                }

                // 🔹 Crear el XML
                var doc = new XDocument(
                    new XElement("Socios",
                        listaSocios.Select(s => new XElement("Socio",
                            new XElement("Id", s.Id),
                            new XElement("Nombre", s.Nombre),
                            new XElement("Email", s.Email),
                            new XElement("FechaAlta", s.FechaAlta.ToString("o"))
                        ))
                    )
                );

                // 🔹 Guardar el archivo
                var rutaCompleta = System.IO.Path.GetFullPath(rutaSalida);
                doc.Save(rutaCompleta);

                Console.WriteLine($"Socios exportados a XML correctamente en:\n{rutaCompleta}");
            }
        }

    }
}
