using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ninject;
using BLL.Interfaces;
using BLL.Util;
using Курсовой_проект_Система_управления_складом_.Util;
using Курсовой_проект_Система_управления_складом_.ViewModel;
using BLL.Models;

namespace Курсовой_проект_Система_управления_складом_.View
{
    /// <summary>
    /// Логика взаимодействия для ViewLineWrite.xaml
    /// </summary>
    public partial class ViewLineWrite : Window
    {
        public ViewLineWrite(WriteView write)
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("foodshopEntities"));
            IDbCrud db = kernel.Get<IDbCrud>();
            IReportsServiсе reportServ = kernel.Get<IReportsServiсе>();
            InitializeComponent();
            WriteView Wr = write;
            DataContext = new LineWriteViewModel(db, Wr, reportServ, LineWrite);

        }
        private void ButtonCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }
    }
}
