using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Ninject;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Models;
using BLL.Interfaces;
using BLL.Util;
using Курсовой_проект_Система_управления_складом_.Util;
using Курсовой_проект_Система_управления_складом_.ViewModel;



namespace Курсовой_проект_Система_управления_складом_.View
{
    /// <summary>
    /// Логика взаимодействия для Товары.xaml
    /// </summary>
    public partial class Товары : Page
    {

        public Товары()
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("foodshopEntities"));
            IDbCrud db = kernel.Get<IDbCrud>();
            IReportsServiсе report = kernel.Get<IReportsServiсе>();
            InitializeComponent();
            DataContext = new TovarViewModel(db, report);
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
             Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void ButtonAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddTovar f = new AddTovar();
            f.Show();
        }
    }
}
