using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Data;
using GenteFit.Models;
using System.Data.Entity;  

namespace GenteFit.DAO
{
    public class SesionDAO
    {
        public Sesion Insert(Sesion s)
        {
            using (var db = new GenteFitContext())
            {
                db.Sesiones.Add(s);
                db.SaveChanges();
                return s;
            }
        }

        public void Update(Sesion s)
        {
            using (var db = new GenteFitContext())
            {
                var old = db.Sesiones.Find(s.Id);
                if (old == null) return;
                old.FechaHora = s.FechaHora;
                old.Sala = s.Sala;
                old.Monitor = s.Monitor;
                old.AforoMax = s.AforoMax;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new GenteFitContext())
            {
                var s = db.Sesiones.Find(id);
                if (s == null) return;
                db.Sesiones.Remove(s);
                db.SaveChanges();
            }
        }

        public List<Sesion> ListUpcoming()
        {
            using (var db = new GenteFitContext())
                // Include Actividad para evitar lazy-loading fuera del contexto
                return db.Sesiones.Include(s => s.Actividad)
                                  .Where(x => x.FechaHora >= System.DateTime.Now)
                                  .ToList();
        }

        public Sesion GetById(int id)
        {
            using (var db = new GenteFitContext())
                // Incluir Actividad si la UI la va a necesitar
                return db.Sesiones.Include(s => s.Actividad).FirstOrDefault(s => s.Id == id);
        }
    }
}