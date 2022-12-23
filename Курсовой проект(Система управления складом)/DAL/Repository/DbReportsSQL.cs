using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repository
{
     public class DbReportsSQL : IDbReports
    {
        private foodshopEntities db;
        private TovarRepositorySQL tovarRepository;
        private PostavshikRepositorySQL postavshikRepository;
        private OrderRepositorySQL orderRepository;
        private WriteRepositorySQL writeRepository;
        private CategoriesRepositorySQL categoriesRepository;
        private LineOrderRepositorySQL lineorderRepository;
        private TovarReportsRepositorySQL tovarReportsRepository;
        private LineWriteRepositorySQL linewriteRepository;
        public DbReportsSQL()
        {
            db = new foodshopEntities();
        }

        public IRepository<Tovar> tovar
        {
            get
            {
                if (tovarRepository == null)
                    tovarRepository = new TovarRepositorySQL(db);
                return tovarRepository;
            }
        }
        public IRepository<Postavshik> postavshik
        {
            get
            {
                if (postavshikRepository == null)
                    postavshikRepository = new PostavshikRepositorySQL(db);
                return postavshikRepository;
            }
        }

        public IRepository<Order> order
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepositorySQL(db);
                return orderRepository;
            }
        }

        public IRepository<Write> write
        {
            get
            {
                if (writeRepository == null)
                    writeRepository = new WriteRepositorySQL(db);
                return writeRepository;
            }
        }

        public IRepository<CategoryTovara> categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepositorySQL(db);
                return categoriesRepository;
            }
        }

        public IRepository<LineOrder> lineOrder
        {
            get
            {
                if (lineorderRepository == null)
                    lineorderRepository = new LineOrderRepositorySQL(db);
                return lineorderRepository;
            }
        }

        public IRepository<LineWrite> lineWrite
        {
            get
            {
                if (linewriteRepository == null)
                    linewriteRepository = new LineWriteRepositorySQL(db);
                return linewriteRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (tovarReportsRepository == null)
                    tovarReportsRepository = new TovarReportsRepositorySQL(db);
                return tovarReportsRepository;
            }
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
