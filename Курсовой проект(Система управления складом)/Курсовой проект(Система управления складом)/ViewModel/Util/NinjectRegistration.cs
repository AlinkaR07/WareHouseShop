using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BLL;
using BLL.Interfaces;
using BLL.Services;


namespace Курсовой_проект_Система_управления_складом_.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IReportsServiсе>().To<ReportsService>();
            Bind<IDbCrud>().To<DbCrudOperations>();
        }
    }
}
