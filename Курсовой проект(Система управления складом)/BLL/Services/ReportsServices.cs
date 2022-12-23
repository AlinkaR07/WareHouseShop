using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using BLL.Models;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ReportsService : IReportsServiсе
    {
        private IDbReports db;
        public ReportsService(IDbReports repos)
        {
            db = repos;
        }

        //выполнить ХП
        public List<TovarView> ExecuteSPCountTovar(int count)
        {
            return db.Reports.ExecuteSPCountTovar(count).Select(i => new TovarView { Name = i.Name, DateExpiration = (DateTime)i.DateExpiration, Category = i.Category, Price = i.Price, Count = i.Count }).ToList();
        }

        public List<TovarView> ExecuteSPDateTovar(DateTime date)
        {
            return db.Reports.ExecuteSPDateTovar(date).Select(i => new TovarView { Name = i.Name, DateExpiration = (DateTime)i.DateExpiration, Category = i.Category, Price = i.Price, Count = i.Count}).ToList();
        }
        public List<TovarView> ExecuteSPQueryTovar(string name)
        {
            return db.Reports.ExecuteSPQueryTovar(name).Select(i => new TovarView { CodTovara=i.CodTovara, Name = i.Name, DateExpiration = (DateTime)i.DateExpiration, Category = i.Category, Price = i.Price, Count = i.Count }).ToList();
        }

        public List<OrderView> ExecuteSPOrder(string status)
        {
            return db.Reports.ExecuteSPOrder(status).Select(i => new OrderView {  DataOrder = i.DataOrder, DataShipment = i.DataShipment, NameOrganizationPostavshik_FK_ = i.NameOrganizationPostavshik_FK_, StatusOrder = i.StatusOrder, FIOworker_FK_ = i.FIOworker_FK_ }).ToList();
        }

        public List<LineOrderView> ExecuteSPViewLineOrder(int number)
        {
            return db.Reports.ExecuteSPViewLineOrder(number).Select(i => new LineOrderView { Name=i.Name, CountOrder=i.CountOrder, CountShipment=i.CountShipment, DataManuf=i.DataManuf, NumberOrder_FK_=i.NumberOrder_FK_, PurchasePrice=i.PurchasePrice, CodTovara_FK_=i.CodTovara_FK_}).ToList();
        }
        public List<LineOrderView> ExecuteSPGetLineOrder(int number)
        {
            return db.Reports.ExecuteSPGetLineOrder( number).Select(i => new LineOrderView { CodTovara_FK_ = i.CodTovara_FK_, CountOrder = i.CountOrder, CountShipment = i.CountShipment, DataManuf = i.DataManuf, NumberOrder_FK_ = i.NumberOrder_FK_, PurchasePrice = i.PurchasePrice }).ToList();
        }
        public List<LineWriteView> ExecuteSPViewLineWrite(int number)
        {
            return db.Reports.ExecuteSPViewLineWrite(number).Select(i => new LineWriteView { CodTovara_FK_=i.CodTovara_FK_, Name= i.Name, Summa = i.Summa, Count = i.Count, NumberActWrite_FK_=i.NumberActWrite_FK_}).ToList();
        }
    }
}
