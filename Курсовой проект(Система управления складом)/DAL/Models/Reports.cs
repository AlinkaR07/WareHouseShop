using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
     public class TovarReports
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateExpiration { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CodTovara { get; set; }

    }

    public class OrderReports
    {
        public DateTime? DataOrder { get; set; }
        public DateTime? DataShipment { get; set; }
        public string StatusOrder { get; set; }
        public string NameOrganizationPostavshik_FK_ { get; set; }
        public string FIOworker_FK_ { get; set; }

    }

    public class LineOrderReports
    {
        public int CountOrder { get; set; }
        public string PurchasePrice { get; set; }
        public int? CountShipment { get; set; }
        public int CodTovara_FK_ { get; set; }
        public string Name { get; set; }
        public int NumberOrder_FK_ { get; set; }
        public System.DateTime? DataManuf { get; set; }

    }

    public class LineWriteReports
    {
        public double Summa { get; set; }
        public int Count { get; set; }
        public int NumberActWrite_FK_ { get; set; }
        public int CodTovara_FK_ { get; set; }
        public string Name { get; set; }
        
    }

}
