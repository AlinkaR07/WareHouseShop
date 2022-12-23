using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class OrderView
    {
        public int Number { get; set; }
        public DateTime? DataOrder { get; set; }
        public DateTime? DataShipment { get; set; }
        public string StatusOrder { get; set; }
        public string NameOrganizationPostavshik_FK_ { get; set; }
        public string FIOworker_FK_ { get; set; }
        public List<LineOrderView> LineOrders { get; set; } 

        public OrderView()
        {

        }

        public OrderView(Order o)
        {
            Number = o.Number;
            DataOrder = o.DataOrder;
            DataShipment = o.DataShipment;
            StatusOrder = o.StatusOrder;
            NameOrganizationPostavshik_FK_ = o.NameOrganizationPostavshik_FK_;
            FIOworker_FK_ = o.FIOworker_FK_;
            LineOrders = o.LineOrder.Select(l => new LineOrderView(l)).ToList();
        }
    }
}
