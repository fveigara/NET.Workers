using GenteFit.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GenteFit.Data;

//namespace GenteFit.Utils
//{
    //public static class XmlImporter
    //{
        //public static void ImportClientes(string path)
        //{
            //if (!File.Exists(path)) return;

            //var serializer = new XmlSerializer(typeof(List<Cliente>));
            //List<Cliente> clientes;

            //using (var reader = new StreamReader(path))
            //{
                //clientes = (List<Cliente>)serializer.Deserialize(reader);
            //}

            //using (var db = new GenteFitContext())
            //{
                //foreach (var c in clientes)
                //{
                    //bool existe = db.Clientes.Any(x => x.Documento == c.Documento);
                    //if (existe) continue;

                    //c.Id = 0; // evita conflicto PK
                    //db.Clientes.Add(c);
                //}

                //db.SaveChanges();
            //}
        //}
        //public static void ImportProductos(string path)
        //{
            //if (!File.Exists(path)) return;

            //var serializer = new XmlSerializer(typeof(List<Producto>));
            //List<Producto> productos;

            //using (var reader = new StreamReader(path))
            //{
                //productos = (List<Producto>)serializer.Deserialize(reader);
            //}

            //using (var db = new GenteFitContext())
            //{
                //foreach (var c in productos)
                //{
                    //bool existe = db.Productos.Any(x => x.Nombre == c.Nombre);
                    //if (existe) continue;

                    //c.Id = 0; // evita conflicto PK
                    //db.Productos.Add(c);
                //}

                //db.SaveChanges();
            //}
        //}
    //}
//}