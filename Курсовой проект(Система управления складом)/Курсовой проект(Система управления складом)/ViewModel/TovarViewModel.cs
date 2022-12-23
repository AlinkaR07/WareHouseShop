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
using Курсовой_проект_Система_управления_складом_.View;
using System.Windows;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class TovarViewModel : INotifyPropertyChanged
    {

        DataGrid Grid;

        IDbCrud dbo;
        IReportsServiсе report;


        public ObservableCollection<TovarView> listTovar { get; set; } 
        public List<TovarView> AllTovar { get; set; }                            // для фильтрации
        public string Filter { get; set; }

        public TovarViewModel(IDbCrud dbcrud, IReportsServiсе reportserv)
        {
            AddTovarViewModel.TovarAdd += OnTovarAdd;                                                  // подписка на событие добавления товара
            dbo = dbcrud;
            report = reportserv;
            LoadTovar();
        }
        public void LoadTovar()
        {
            AllTovar = dbo.GetAllTovar();
            listTovar = new ObservableCollection<TovarView>(AllTovar);
            onPropertyChanged(nameof(listTovar));
        }

        private TovarView selectedTovar;
        public TovarView SelectedTovar
        {
            get 
            { 
                return selectedTovar;
            }
            set
            {
                selectedTovar = value;
                OnPropertyChanged(nameof(selectedTovar));
            }
        }

        private RelayCommand removeTovar;
        public RelayCommand RemoveTovar
        {
            get
            {
               
                return removeTovar ??
                  (removeTovar = new RelayCommand(obj =>
                  
                    {
                        try
                        {
                            TovarView tovar = obj as TovarView;
                            if (tovar != null)
                            {

                                dbo.DeleteTovar(tovar.CodTovara);
                                listTovar.Remove(tovar);
                                LoadTovar();
                            }
                            MessageBox.Show("Товар успешно удален!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }));
            }
        }


        private RelayCommand updateTovar;
        public RelayCommand UpdateTovar
        {
            get
            {
                return updateTovar ??
                  (updateTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                          TovarView tovar = obj as TovarView;
                          if (tovar != null)
                          {
                              int n = listTovar.IndexOf(selectedTovar);
                              TovarView t = new TovarView();
                              t.CodTovara = listTovar[n].CodTovara;
                              t.Name = listTovar[n].Name;
                              t.Count = listTovar[n].Count;
                              t.DateExpiration = listTovar[n].DateExpiration;
                              t.Category = listTovar[n].Category;
                              t.Price = listTovar[n].Price;
                              dbo.UpdateTovar(t);
                              listTovar.Remove(tovar);
                              LoadTovar();

                              MessageBox.Show("Товар успешно изменен!");
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand filterTovar;
        public RelayCommand FilterTovar
        {
            get
            {
                return filterTovar ??
                  (filterTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                             
                             listTovar = new ObservableCollection<TovarView>(AllTovar.Where(t => t.Name.StartsWith(Filter)));
                              onPropertyChanged(nameof(listTovar));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private void OnTovarAdd()                                                                   // функция события добавления заказа(загрузка обновленной таблицы)
        {
            LoadTovar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler propertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(prop));
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
