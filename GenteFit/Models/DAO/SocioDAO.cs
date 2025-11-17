using GenteFit.Data;
using GenteFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFit.DAO
{
    internal class SocioDAO
    {
        public List<Socio> GetAll()
        {
            using (var db = new GenteFitContext())
                return db.Socios.ToList();
        }

        public Socio GetById(int id)
        {
            using (var db = new GenteFitContext())
                return db.Socios.Find(id);
        }

        public void Insert(Socio socio)
        {
            using (var db = new GenteFitContext())
            {
                db.Socios.Add(socio);
                db.SaveChanges();
            }
        }

        public void Update(Socio socio)
        {
            using (var db = new GenteFitContext())
            {
                var s = db.Socios.Find(socio.Id);
                if (s == null) return;
                s.Nombre = socio.Nombre;
                s.Email = socio.Email;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new GenteFitContext())
            {
                var socio = db.Socios.Find(id);
                if (socio == null) return;
                db.Socios.Remove(socio);
                db.SaveChanges();
            }
        }
    }
}