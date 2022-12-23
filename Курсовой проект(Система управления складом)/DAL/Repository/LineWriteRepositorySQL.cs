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
    class LineWriteRepositorySQL : IRepository<LineWrite>
    {
        private foodshopEntities db;
        public LineWriteRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public LineWrite GetItem(int cod)
        {
            return db.LineWrite.Find(cod);
        }
        public LineWrite GetItem(string cod)
        {
            return db.LineWrite.Find(cod);
        }
        public LineWrite GetItem(DateTime date, string name)
        {
            return db.LineWrite.Find(date, name);
        }
        public List<LineWrite> GetList()
        {
            return db.LineWrite.ToList();
        }

        public void Create(LineWrite lineWrite)
        {
            db.LineWrite.Add(lineWrite);
        }

        public void Update(LineWrite lineWrite)
        {
            db.Entry(lineWrite).State = EntityState.Modified;
        }

        public void Delete(int cod)
        {
            LineWrite Linewrite = db.LineWrite.Find(cod);
            if (Linewrite != null)
                db.LineWrite.Remove(Linewrite);
        }
        public void Delete(string cod)
        {
            LineWrite Linewrite = db.LineWrite.Find(cod);
            if (Linewrite != null)
                db.LineWrite.Remove(Linewrite);
        }
    }
}
