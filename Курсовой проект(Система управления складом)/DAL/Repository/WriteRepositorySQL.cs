﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repository
{
    class WriteRepositorySQL : IRepository<Write>
    {
        private foodshopEntities db;
        public WriteRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public Write GetItem(int cod)
        {
            return db.Write.Find(cod);
        }
        public Write GetItem(string cod)
        {
            return db.Write.Find(cod);
        }
        public Write GetItem(DateTime date, string name)
        {
            return db.Write.Find(date, name);
        }
        public List<Write> GetList()
        {
            return db.Write.ToList();
        }

        public void Create(Write write)
        {
            db.Write.Add(write);
        }

        public void Update(Write write)
        {
            db.Entry(write).State = EntityState.Modified;
        }
        public void Delete(int cod)
        {
            Write Write = db.Write.Find(cod);
            if (Write != null)
                db.Write.Remove(Write);
        }
        public void Delete(string cod)
        {
            Write Write = db.Write.Find(cod);
            if (Write != null)
                db.Write.Remove(Write);
        }
    }
}
