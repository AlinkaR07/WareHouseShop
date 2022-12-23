using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class WriteView
    {
        public System.DateTime DataWrite { get; set; }
        public int NumberAct { get; set; }
        public string FIOworker_FK_ { get; set; }
        public List<LineWriteView> LineWrites { get; set; }

        public WriteView()
        {

        }

        public WriteView(Write w)
        {
            DataWrite = w.DataWrite;
            NumberAct = w.NumberAct;
            FIOworker_FK_ = w.FIOworker_FK_;
            LineWrites = w.LineWrite.Select(l => new LineWriteView(l)).ToList();
        }
    }
}
