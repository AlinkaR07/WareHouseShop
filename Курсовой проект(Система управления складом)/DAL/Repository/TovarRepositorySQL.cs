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
    class TovarRepositorySQL : IRepository<Tovar>
    {
        private foodshopEntities db;
        public TovarRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public Tovar GetItem(int cod)
        {
            return db.Tovar.Find(cod);
        }
        public Tovar GetItem(string cod)
        {
            return db.Tovar.Find(cod);
        }
        public Tovar GetItem(DateTime date, string name)
        {
            return db.Tovar.Find(date, name);
        }
        public List<Tovar> GetList()
        {
            return db.Tovar.ToList();
        }

        public void Create(Tovar tovar)
        {
            db.Tovar.Add(tovar);
        }

        public void Update(Tovar tovar)
        {
            db.Entry(tovar).State = EntityState.Modified;
        }

        public void Delete(int cod)
        {
            Tovar Tovar = db.Tovar.Find(cod);
            if (Tovar != null)
                db.Tovar.Remove(Tovar);
        }
        public void Delete(string cod)
        {
            Tovar Tovar = db.Tovar.Find(cod);
            if (Tovar != null)
                db.Tovar.Remove(Tovar);
        }
    }
}
