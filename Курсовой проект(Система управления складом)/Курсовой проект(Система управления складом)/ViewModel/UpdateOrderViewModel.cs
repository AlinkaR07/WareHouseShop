using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class UpdateOrderViewModel : INotifyPropertyChanged
    {
        Border order;
        // Grid FormOrder;

        public static Action OrderAdd;                           // событие на добавление заказа в таблицу заказов
        public string FIOWorker { get; set; }
        public string Postavshik { get; set; }
        public DateTime DateOrder { get; set; }
        public string CodTovara { get; set; }


        IDbCrud dbo;
        public ObservableCollection<PostavshikView> listComboboxPost { get; set; }
        public ObservableCollection<LineOrderView> listLineOrder { get; set; }
        public ObservableCollection<TovarView> listComboboxTovar { get; set; }
        public UpdateOrderViewModel(IDbCrud dbcrud, Border Order)
        {
            dbo = dbcrud;
            LoadComboboxPost();
            LoadComboboxTovar();
            FIOWorker = "Прокофьева Е.И.";
            order = Order;
            //Postavshik = selectedOrder.NameOrganizationPostavshik_FK_;
            // FormOrder = grid;
            DateOrder = DateTime.Today;
            listLineOrder = new ObservableCollection<LineOrderView>();
        }

        private OrderView selectedOrder;
        public OrderView SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                onPropertyChanged(nameof(selectedOrder));
            }
        }

       
        private RelayCommand updateOrder;
        public RelayCommand UpdateOrder
        {
            get
            {
                return updateOrder ??
                  (updateOrder = new RelayCommand(obj =>
                  {
                      try
                      {
                          OrderView order = obj as OrderView;
                          if (order != null)
                          {
                              dbo.UpdateOrder(order);
                              OrderAdd?.Invoke();                                          // реакция на изменение заказа
                          }
                          MessageBox.Show("Заказ успешно изменен!");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        // команда печати
        private RelayCommand print;
        public RelayCommand Print
        {
            get
            {
                return print ??
                  (print = new RelayCommand(obj =>
                  {
                      try
                      {
                          PrintDialog p = new PrintDialog();
                          if (p.ShowDialog() == true)
                          {
                              p.PrintVisual(order, "Печать");
                          }
                          MessageBox.Show("Заказ напечатан!");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        public void LoadComboboxPost()
        {
            listComboboxPost = new ObservableCollection<PostavshikView>(dbo.GetAllPostavshiki());

        }

        public void LoadComboboxTovar()
        {
            listComboboxTovar = new ObservableCollection<TovarView>(dbo.GetAllTovar());
        }

        public void LoadLineOrder()
        {
            // listLineOrder = new ObservableCollection<LineOrderView>(dbo.());
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
