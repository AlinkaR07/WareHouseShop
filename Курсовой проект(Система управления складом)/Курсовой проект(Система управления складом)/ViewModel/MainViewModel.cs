using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Ninject;
using Курсовой_проект_Система_управления_складом_.Util;
using BLL.Interfaces;

namespace Курсовой_проект_Система_управления_складом_.View.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Page Home = new Главная_страница();
        private Page Order = new Заказы();
        private Page Write = new АктыСписания();
        private Page Postavshik = new Поставщики();
        private Page Tovar = new Товары();
        private Page Reports = new Reports();
        private Page _CurPage = new Главная_страница();           // текущая открывающаяся страница

        public Page CurPage                            // получение текущей страницы
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }

        public ICommand OpenWritePage
        {
            get
            {
                return new RelayCommand(() => CurPage = Write);
            }
        }

        public ICommand OpenPostavshikPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Postavshik);
            }
        }

        public ICommand OpenHomePage
        {
            get
            {
                return new RelayCommand(() => CurPage = Home);
            }
        }

        public ICommand OpenTovarPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Tovar);

            }
        }

        public ICommand OpenOrderPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Order);
            }
        }

        public ICommand OpenReportsPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Reports);
            }
        }
    }
}
