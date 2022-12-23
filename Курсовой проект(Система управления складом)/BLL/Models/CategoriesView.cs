using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Models
{
    public class CategoriesView
    {
        public string CategoryName { get; set; }

        public CategoriesView()
        {

        }

        public CategoriesView(CategoryTovara ct)
        {
            CategoryName = ct.CategoryName;
        }
    }
}
