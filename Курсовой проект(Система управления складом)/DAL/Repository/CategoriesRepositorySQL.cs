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
    class CategoriesRepositorySQL : IRepository<CategoryTovara>
    {
        private foodshopEntities db;
        public CategoriesRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<CategoryTovara> GetList()
        {
            return db.CategoryTovara.ToList();
        }

        public CategoryTovara GetItem(int cod)
        {
            return db.CategoryTovara.Find(cod);
        }
        public CategoryTovara GetItem(string cod)
        {
            return db.CategoryTovara.Find(cod);
        }
        public CategoryTovara GetItem(DateTime date, string name)
        {
            return db.CategoryTovara.Find(date, name);
        }
        public void Create(CategoryTovara categoryTovara)
        {
            db.CategoryTovara.Add(categoryTovara);
        }

        public void Update(CategoryTovara categorytovara)
        {
            db.Entry(categorytovara).State = EntityState.Modified;
        }
        public void Delete(int cod)
        {
            CategoryTovara Category = db.CategoryTovara.Find(cod);
            if (Category != null)
                db.CategoryTovara.Remove(Category);
        }

        public void Delete(string cod)
        {
            CategoryTovara Category = db.CategoryTovara.Find(cod);
            if (Category != null)
                db.CategoryTovara.Remove(Category);
        }

    }
}
