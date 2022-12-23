using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repository
{
    class PostavshikRepositorySQL : IRepository<Postavshik>
    {
        private foodshopEntities db;
        public PostavshikRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public Postavshik GetItem(int cod)
        {
            return db.Postavshik.Find(cod);
        }
        public Postavshik GetItem(string cod)
        {
            return db.Postavshik.Find(cod);
        }
        public Postavshik GetItem(DateTime date, string name)
        {
            return db.Postavshik.Find(date, name);
        }
        public List<Postavshik> GetList()
        {
            return db.Postavshik.ToList();
        }

        public void Create(Postavshik postavshik)
        {
            db.Postavshik.Add(postavshik);
        }

        public void Update(Postavshik postavshik)
        {
            db.Entry(postavshik).State = EntityState.Modified;
        }

        public void Delete(int cod)
        {
            Postavshik Postavshik = db.Postavshik.Find(cod);
            if (Postavshik != null)
                db.Postavshik.Remove(Postavshik);
        }
        public void Delete(string cod)
        {
            Postavshik Postavshik = db.Postavshik.Find(cod);
            if (Postavshik != null)
                db.Postavshik.Remove(Postavshik);
        }
    }
}
