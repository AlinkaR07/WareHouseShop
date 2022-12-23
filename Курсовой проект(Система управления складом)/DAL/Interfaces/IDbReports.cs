using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;


namespace DAL.Interfaces
{
    public interface IDbReports
    {
        IRepository<Tovar> tovar { get; }
        IRepository<Postavshik> postavshik { get; }
        IRepository<Order> order { get; }
        IRepository<LineOrder> lineOrder { get; }
        IRepository<Write> write { get; }
        IRepository<LineWrite> lineWrite { get; }
        IRepository<CategoryTovara> categories { get; }
        IReportsRepository Reports { get; } 
        int Save();
    }
}
