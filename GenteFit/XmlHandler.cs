using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Data;
using GenteFit.Models;
using System.Globalization;
using System.Xml.Linq;

namespace GenteFit
{
    public static class XmlHandler
    {
        public static void ImportarSociosDesdeXml(string rutaXml)
        {
            var doc = XDocument.Load(rutaXml);
            using (var db = new GenteFitContext())
            {
                foreach (var el in doc.Root.Elements("Socio"))
                {
                    var socio = new Socio
                    {
                        Nombre = (string)el.Element("Nombre"),
                        Email = (string)el.Element("Email"),
                        FechaAlta = DateTime.Parse((string)el.Element("FechaAlta"), CultureInfo.InvariantCulture)
                    };
                    db.Socios.Add(socio);
                }
                db.SaveChanges();
            }
        }

        public static void ExportarSociosAXml(string rutaSalida)
        {
            using (var db = new GenteFitContext())
            {
                var socios = db.Socios.ToList(); // <- fuerza la ejecución en memoria

                var doc = new XDocument(
                    new XElement("Socios",
                        socios.Select(s =>
                            new XElement("Socio",
                                new XElement("Id", s.Id),
                                new XElement("Nombre", s.Nombre),
                                new XElement("Email", s.Email),
                                new XElement("FechaAlta", s.FechaAlta.ToString("o"))
                            )
                        )
                    )
                );
                doc.Save(rutaSalida);
            }
        }

    }
}
