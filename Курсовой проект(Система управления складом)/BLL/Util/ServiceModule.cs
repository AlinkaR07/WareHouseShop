using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DAL.Interfaces;
using DAL.Repository;


namespace BLL.Util
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IDbReports>().To<DbReportsSQL>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
