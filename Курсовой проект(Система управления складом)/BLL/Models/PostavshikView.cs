using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class PostavshikView
    {
        public string NameOrganization { get; set; }
        public string FIOdirector { get; set; }
        public string INN { get; set; }
        public string NumberAccount { get; set; }

        public PostavshikView()
        {

        }

        public PostavshikView(Postavshik p)
        {
            NameOrganization = p.NameOrganization;
            FIOdirector = p.FIOdirector;
            INN = p.INN;
            NumberAccount = p.NumberAccount;
        }

    }
}
