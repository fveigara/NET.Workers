using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Data;
using GenteFit.Models;

namespace GenteFit.DAO
{
    public class ActividadDAO
    {
        public Actividad Insert(Actividad a)
        {
            using (var db = new GenteFitContext())
            {
                db.Actividades.Add(a);
                db.SaveChanges();
                return a;
            }
        }

        public void Update(Actividad a)
        {
            using (var db = new GenteFitContext())
            {
                var x = db.Actividades.Find(a.Id);
                if (x == null) return;
                x.Nombre = a.Nombre;
                x.Descripcion = a.Descripcion;
                x.Intensidad = a.Intensidad;
                db.SaveChanges();
            }
        }
        
        public void Delete(int id)
        {
            using (var db = new GenteFitContext())
            {
                var a = db.Actividades.Find(id);
                if (a == null) return;
                db.Actividades.Remove(a);
                db.SaveChanges();
            }
        }

        public List<Actividad> GetAll()
        {
            using (var db = new GenteFitContext())
                return db.Actividades.ToList();
        }
    }
}