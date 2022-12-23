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
using Курсовой_проект_Система_управления_складом_.ViewModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class AddTovarViewModel : INotifyPropertyChanged
    {
        public static Action TovarAdd;                                            // событие на добавление товара в таблицу товаров
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }

        IDbCrud dbo;
        public  ObservableCollection<CategoriesView> listCategories { get; set; }

        public AddTovarViewModel(IDbCrud dbcrud)
        {
            dbo = dbcrud;
            LoadCategories();
            Date = DateTime.Today;
        }

 

        private RelayCommand addTovar;
        public RelayCommand AddTovar
        {
            get
            {
                return addTovar ??
                  (addTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                          TovarView t = new TovarView();
                          t.Name = Name;
                          t.Count = int.Parse(Count);
                          t.DateExpiration = Date;
                          t.Category = Category;
                          t.Price = int.Parse(Price);
                          dbo.CreateTovar(t);

                          MessageBox.Show("Товар успешно добавлен!");
                          TovarAdd?.Invoke();                                                      // реакция на добавление нового товара
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        public void LoadCategories()
        {
            listCategories = new ObservableCollection<CategoriesView>(dbo.GetAllCategories());
            onPropertyChanged(nameof(listCategories));
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
