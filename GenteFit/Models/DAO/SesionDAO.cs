using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFit.Data;
using GenteFit.Models;  

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

        public List<Sesion> ListUpcoming()
        {
            using (var db = new GenteFitContext())
                return db.Sesiones.Where(x => x.FechaHora >= System.DateTime.Now).ToList();
        }

        public Sesion GetById(int id)
        {
            using (var db = new GenteFitContext())
                return db.Sesiones.Find(id);
        }
    }
}