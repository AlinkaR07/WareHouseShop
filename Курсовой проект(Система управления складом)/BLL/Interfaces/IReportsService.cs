using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Models;
using BLL.Interfaces;

namespace BLL.Interfaces
{
    public interface IReportsServiсе
    {
        List<TovarView> ExecuteSPCountTovar(int count);
        List<TovarView> ExecuteSPDateTovar(DateTime date);
        List<OrderView> ExecuteSPOrder(string status);
        List<LineOrderView> ExecuteSPViewLineOrder(int number);
        List<LineOrderView> ExecuteSPGetLineOrder(int number);
        List<LineWriteView> ExecuteSPViewLineWrite(int number);
        List<TovarView> ExecuteSPQueryTovar(string name);
    }
}
