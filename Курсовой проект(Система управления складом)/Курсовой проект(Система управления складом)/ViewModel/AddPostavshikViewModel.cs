using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class AddPostavshikViewModel : INotifyPropertyChanged
    {

        public static Action PostavshikAdd;                           // событие на добавление поставщика в таблицу поставщиков
        public string Name { get; set; }
        public string FIO { get; set; }
        public string INN { get; set; }
        public string Account { get; set; }

        IDbCrud dbo;

        public AddPostavshikViewModel(IDbCrud dbcrud)
        {
            dbo = dbcrud;
        }

        private RelayCommand addPostavshik;
        public RelayCommand AddPostavshik
        {
            get
            {
                return addPostavshik ??
                  (addPostavshik = new RelayCommand(obj =>
                  {
                      try
                      {
                          PostavshikView p = new PostavshikView();
                          p.NameOrganization = Name;
                          p.FIOdirector = FIO;
                          p.INN = INN;
                          p.NumberAccount = Account;
                          dbo.CreatePostavshik(p);

                          MessageBox.Show("Поставщик успешно добавлен!");
                          PostavshikAdd.Invoke();                                          // реакция на добавление нового поставщика
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            onPropertyChanged(PropertyName);
            return true;
        }
    }
}
