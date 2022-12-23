using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
   public class TovarView
    {
        public int CodTovara { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateExpiration { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }


        public TovarView()
        {

        }

        public TovarView(Tovar t)
        {
            CodTovara = t.CodTovara;
            Name = t.Name;
            DateExpiration = t.DateExpiration;
            Category = t.Category;
            Price = t.Price;
            Count = t.Count??0;
        }
    }

}
