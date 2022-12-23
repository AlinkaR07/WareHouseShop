using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class LineOrderView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PurchasePrice { get; set; }
        public int CountOrder { get; set; }
        public Nullable<int> CountShipment { get; set; }
        public int CodTovara_FK_ { get; set; }
        public int NumberOrder_FK_ { get; set; }
        public Nullable<System.DateTime> DataManuf { get; set; }

        public LineOrderView()
        {

        }

        public LineOrderView(LineOrder lo)
        {
            ID = lo.ID;
            Name = lo.Tovar.Name;
            PurchasePrice = lo.PurchasePrice;
            CountShipment = lo.CountShipment;
            CountOrder = lo.CountOrder;
            CodTovara_FK_ = lo.CodTovara_FK_;
            NumberOrder_FK_ = lo.NumberOrder_FK_;
            DataManuf = lo.DataManuf;
        }
    }
}
