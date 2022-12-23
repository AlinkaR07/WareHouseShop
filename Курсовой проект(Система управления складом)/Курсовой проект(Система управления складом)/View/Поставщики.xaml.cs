using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Ninject;
using Курсовой_проект_Система_управления_складом_.Util;
using Курсовой_проект_Система_управления_складом_.ViewModel;
using BLL.Util;
using BLL.Interfaces;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовой_проект_Система_управления_складом_.View
{
    /// <summary>
    /// Логика взаимодействия для Поставщики.xaml
    /// </summary>
    public partial class Поставщики : Page
    {
        public Поставщики()
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("foodshopEntities"));
            IDbCrud db = kernel.Get<IDbCrud>();
            InitializeComponent();
            DataContext = new PostavshikViewModel(db);
        }

        private void ButtonCloseForm_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Maximized;
        }

        private void ButtonAddPostavshik_Click(object sender, RoutedEventArgs e)
        {
            AddPostavshik f = new AddPostavshik();
            f.Show();
        }
    }
}
