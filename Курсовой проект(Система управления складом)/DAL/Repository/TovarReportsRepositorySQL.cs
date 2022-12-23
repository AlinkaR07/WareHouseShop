using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repository
{
    class TovarReportsRepositorySQL : IReportsRepository
    {
        private foodshopEntities db;
        private class SPResultT
        {
            public int Number { get; set; }
            public string Name { get; set; }
            public Nullable<System.DateTime> DateExpiration { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public int Count { get; set; }
            public int CodTovara { get; set; }
        }

        private class SPResultO
        {
            public DateTime? DataOrder { get; set; }
            public DateTime? DataShipment { get; set; }
            public string StatusOrder { get; set; }
            public string NameOrganizationPostavshik_FK_ { get; set; }
            public string FIOworker_FK_ { get; set; }
        }

        private class SPResultLo
        {
            public int CodTovara_FK_ { get; set; }
            public int CountOrder { get; set; }
            public string PurchasePrice { get; set; }
            public int? CountShipment { get; set; }
            public string Name { get; set; }
            public int NumberOrder_FK_ { get; set; }
            public System.DateTime? DataManuf { get; set; }
        }

        private class SPResultLw
        {
            public double Summa { get; set; }
            public int Count { get; set; }
            public int NumberActWrite_FK_ { get; set; }
            public string Name { get; set; }
        }
        public class SPResultW
        {
            public DateTime DateWrite { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
            public int Summa { get; set; }
            public string Category { get; set; }
            public string FIOWorker { get; set; }

        }
        public TovarReportsRepositorySQL(foodshopEntities dbcontext)
        {
            this.db = dbcontext;
        }
        //выполнить ХП
        public List<TovarReports> ExecuteSPCountTovar(int count)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@count", count);

            var result = db.Database.SqlQuery<SPResultT>("CountTovar @count", new object[] { param1 }).ToList();
            var data = result.Select(i => new TovarReports
            {
                Name = i.Name,
                DateExpiration = i.DateExpiration,
                Category = i.Category,
                Price = i.Price,
                Count = i.Count
            }).ToList();
            return data;

        }

        public List<TovarReports> ExecuteSPDateTovar(DateTime date)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@count", date);

            var result = db.Database.SqlQuery<SPResultT>("DateTovar @count", new object[] { param1 }).ToList();
            var data = result.Select(i => new TovarReports
            {
                Name = i.Name,
                DateExpiration = i.DateExpiration,
                Category = i.Category,
                Price = i.Price,
                Count = i.Count
            }).ToList();
            return data;

        }

        public List<TovarReports> ExecuteSPQueryTovar(string name)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@st", name);

            var result = db.Database.SqlQuery<SPResultT>("FilterTovar @st", new object[] { param1 }).ToList();
            var data = result.Select(i => new TovarReports
            {
                Number = i.Number,
                Name = i.Name,
                DateExpiration = i.DateExpiration,
                Category = i.Category,
                Price = i.Price,
                Count = i.Count,
                CodTovara=i.CodTovara
            }).ToList();
            return data;

        }

        public List<OrderReports> ExecuteSPOrder(string status)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@count", status);

            var result = db.Database.SqlQuery<SPResultO>("DateTovar @count", new object[] { param1 }).ToList();
            var data = result.Select(i => new OrderReports
            {
                DataOrder = i.DataOrder,
                DataShipment = i.DataShipment,
                NameOrganizationPostavshik_FK_ = i.NameOrganizationPostavshik_FK_,
                StatusOrder = i.StatusOrder,
                FIOworker_FK_ = i.FIOworker_FK_
            }).ToList();
            return data;

        }
        public List<LineOrderReports> ExecuteSPViewLineOrder(int number)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@numberOrder", number);

            var result = db.Database.SqlQuery<SPResultLo>("LineOrderView @numberOrder", new object[] { param1 }).ToList();
            var data = result.Select(i => new LineOrderReports
            {
                Name = i.Name,
                CountOrder = i.CountOrder,
                CountShipment = i.CountShipment,
                DataManuf = i.DataManuf,
                NumberOrder_FK_ = i.NumberOrder_FK_,
                PurchasePrice = i.PurchasePrice,
                CodTovara_FK_ = i.CodTovara_FK_
            }).ToList();
            return data;

        }
        public List<LineOrderReports> ExecuteSPGetLineOrder( int number)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@numberO", number);

            var result = db.Database.SqlQuery<SPResultLo>("GetLineOrder @numberO", new object[] { param1 }).ToList();
            var data = result.Select(i => new LineOrderReports
            {
                CodTovara_FK_ = i.CodTovara_FK_,
                CountOrder = i.CountOrder,
                CountShipment = i.CountShipment,
                DataManuf = i.DataManuf,
                NumberOrder_FK_ = i.NumberOrder_FK_,
                PurchasePrice = i.PurchasePrice,
            }).ToList();
            return data;

        }
        public List<LineWriteReports> ExecuteSPViewLineWrite(int number)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@numberOrder", number);

            var result = db.Database.SqlQuery<SPResultLw>("LineWriteView @numberOrder", new object[] { param1 }).ToList();
            var data = result.Select(i => new LineWriteReports
            {
                Name = i.Name,
                Summa = i.Summa,
                Count = i.Count,
                NumberActWrite_FK_ = i.NumberActWrite_FK_
            }).ToList();
            return data;
        }
    }
}
