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
    class LineOrderRepositorySQL : IRepository<LineOrder>
    {
        private foodshopEntities db;
        public LineOrderRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public LineOrder GetItem(int cod)
        {
            return db.LineOrder.Find(cod);
        }
        public LineOrder GetItem(string cod)
        {
            return db.LineOrder.Find(cod);
        }
        public LineOrder GetItem(DateTime date, string name)
        {
            return db.LineOrder.Find(date, name);
        }
        public List<LineOrder> GetList()
        {
            return db.LineOrder.ToList();
        }

        public void Create(LineOrder lineOrder)
        {
            db.LineOrder.Add(lineOrder);
        }

        public void Update(LineOrder lineorder)
        {
            db.Entry(lineorder).State = EntityState.Modified;
        }

        public void Delete(int cod)
        {
            LineOrder Lineorder = db.LineOrder.Find(cod);
            if (Lineorder != null)
                db.LineOrder.Remove(Lineorder);
        }
        public void Delete(string cod)
        {
            LineOrder Lineorder = db.LineOrder.Find(cod);
            if (Lineorder != null)
                db.LineOrder.Remove(Lineorder);
        }
    }
}
