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
    class OrderRepositorySQL : IRepository<Order>
    {
        private foodshopEntities db;
        public OrderRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public Order GetItem(int cod)
        {
            return db.Order.Find(cod);
        }
        public Order GetItem(string cod)
        {
            return db.Order.Find(cod);
        }
        public Order GetItem(DateTime date, string name)
        {
            return db.Order.Find(date, name);
        }
        public List<Order> GetList()
        {
            return db.Order.ToList();
        }

        public void Create(Order order)
        {
            db.Order.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int cod)
        {
            Order Order = db.Order.Find(cod);
            if (Order != null)
                db.Order.Remove(Order);
        }
        public void Delete(string cod)
        {
            Order Order = db.Order.Find(cod);
            if (Order != null)
                db.Order.Remove(Order);
        }
    }
}
