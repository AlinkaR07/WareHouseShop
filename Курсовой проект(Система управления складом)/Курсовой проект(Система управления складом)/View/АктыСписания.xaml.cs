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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ninject;
using BLL.Models;
using BLL.Interfaces;
using BLL.Util;
using Курсовой_проект_Система_управления_складом_.Util;
using Курсовой_проект_Система_управления_складом_.ViewModel;

namespace Курсовой_проект_Система_управления_складом_.View
{
    /// <summary>
    /// Логика взаимодействия для АктыСписания.xaml
    /// </summary>
    public partial class АктыСписания : Page
    {
        public АктыСписания()
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("foodshopEntities"));
            IDbCrud db = kernel.Get<IDbCrud>();
            InitializeComponent();
            DataContext = new WriteViewModel(db);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonCloseForm_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void ButtonAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddWrite f = new AddWrite();
            f.Show();
        }
    }
}
