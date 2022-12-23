using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ninject;
using BLL.Interfaces;
using BLL.Util;
using Курсовой_проект_Система_управления_складом_.Util;
using Курсовой_проект_Система_управления_складом_.ViewModel;

namespace Курсовой_проект_Система_управления_складом_.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("foodshopEntities"));
            IDbCrud db = kernel.Get<IDbCrud>();
            InitializeComponent();
            DataContext = new AddOrderViewModel(db, PrintOrder);
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
        private void ButtonCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }

    }
}
