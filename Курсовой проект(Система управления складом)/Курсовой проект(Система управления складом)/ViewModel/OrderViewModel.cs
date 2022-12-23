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
using System.Data.Linq;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        public ObservableCollection<OrderView> listOrder { get; set; }
        public ObservableCollection<LineOrderView> lineOrderViews { get; set; }
        public List<LineOrderView> AllLineOrder { get; set; }

        public List<OrderView> AllOrder { get; set; }                            // для фильтрации
        public string Filter { get; set; }

        public OrderViewModel(IDbCrud dbcrud)
        {
            AddOrderViewModel.OrderAdd += OnOrderAdd;                                            // подписка на событие добавления заказа
            dbo = dbcrud;
            LoadOrder();
        }

        private void LoadOrder()
        {
            AllOrder = dbo.GetAllOrder();
            listOrder = new ObservableCollection<OrderView>(AllOrder);
            onPropertyChanged(nameof(listOrder));
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

        private RelayCommand removeOrder;
        public RelayCommand RemoveOrder
        {
            get
            {
                return removeOrder ??
                  (removeOrder = new RelayCommand(obj =>
                  {
                      try
                      {
                          OrderView order = obj as OrderView;
                          if (order != null)
                          {
                              dbo.DeleteOrder(order.Number);
                              lineOrderViews = new ObservableCollection<LineOrderView>(AllLineOrder.Where(lo => lo.NumberOrder_FK_ == order.Number));
                              listOrder.Remove(order);
                              foreach(LineOrderView l in lineOrderViews)
                              {
                                  dbo.DeleteLineOrder(l.ID);
                              }
                              LoadOrder();
                          }
                          MessageBox.Show("Заказ успешно удален!");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
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
                              int n = listOrder.IndexOf(selectedOrder);
                              OrderView o = new OrderView();
                              o.Number = listOrder[n].Number;
                              o.DataOrder = listOrder[n].DataOrder;
                              o.DataShipment = listOrder[n].DataShipment;
                              o.StatusOrder = listOrder[n].StatusOrder;
                              o.NameOrganizationPostavshik_FK_ = listOrder[n].NameOrganizationPostavshik_FK_;
                              o.FIOworker_FK_ = listOrder[n].FIOworker_FK_;
                              dbo.UpdateOrder(o);
                              listOrder.Remove(order);
                              LoadOrder();

                              MessageBox.Show("Теперь не забудьте обновить информацию о товарах!");
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }


        private RelayCommand viewOrder;
        public RelayCommand ViewOrder
        {
            get
            {
                return viewOrder ??
                  (viewOrder = new RelayCommand(obj =>
                  {
                      try
                      {
                          OrderView LOrder = obj as OrderView;
                          if (LOrder != null)
                          {
                              ViewLineOrder f = new ViewLineOrder(LOrder);
                              f.Show();
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand filterOrder;
        public RelayCommand FilterOrder
        {
            get
            {
                return filterOrder ??
                  (filterOrder = new RelayCommand(obj =>
                  {
                      try
                      {

                          listOrder = new ObservableCollection<OrderView>(AllOrder.Where(o => o.StatusOrder.StartsWith(Filter)));
                          onPropertyChanged(nameof(listOrder));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        private void OnOrderAdd()                                                              // функция события добавления заказа(загрузка обновленной таблицы)
        {
            LoadOrder();
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
