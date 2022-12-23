using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IReportsRepository
    {
        List<TovarReports> ExecuteSPCountTovar(int count);
        List<TovarReports> ExecuteSPDateTovar(DateTime date);
        List<OrderReports> ExecuteSPOrder(string status);
        List<LineOrderReports> ExecuteSPViewLineOrder(int number);
        List<LineOrderReports> ExecuteSPGetLineOrder(int number);
        List<LineWriteReports> ExecuteSPViewLineWrite(int number);
        List<TovarReports> ExecuteSPQueryTovar(string name);
    }
}
