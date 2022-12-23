using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class LineWriteView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Summa { get; set; }
        public int Count { get; set; }
        public int NumberActWrite_FK_ { get; set; }
        public int CodTovara_FK_ { get; set; }

        public LineWriteView()
        {

        }

        public LineWriteView(LineWrite lw)
        {
            ID = lw.ID;
            Name = lw.Tovar.Name;
            Summa = lw.Summa;
            Count = lw.Count;
            NumberActWrite_FK_ = lw.NumberActWrite_FK_;
            CodTovara_FK_ = lw.CodTovara_FK_;
        }
    }
}
