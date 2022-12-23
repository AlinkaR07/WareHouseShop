using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class LineOrderViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        IReportsServiсе rOrder;

        Grid LineOrder;
        public string NumberO { get; set; }
        public string DateO { get; set; }
        public string PostO { get; set; }
        public string SummaOrder { get; set; }


        OrderView OrderView;

        public ObservableCollection<LineOrderView> listLineOrder { get; set; }

        public ObservableCollection<TovarView> listComboboxTovar { get; set; }

        public LineOrderViewModel(IDbCrud dbcrud, OrderView order, IReportsServiсе repos, Grid Order)
        {
            dbo = dbcrud;
            rOrder = repos;
            LineOrder = Order;                         // для печати
            OrderView = order;                         // передаваемый заказ из таблицы Заказы
            LoadLineOrder(order);
        }

        private LineOrderView selectedLineOrder;
        public LineOrderView SelectedLineOrder
        {
            get
            {
                return selectedLineOrder;
            }
            set
            {
                selectedLineOrder = value;
                onPropertyChanged(nameof(selectedLineOrder));
            }
        }
        private void LoadLineOrder(OrderView order)
        {
            double summaorder = 0;
            int Number = order.Number;
            NumberO = order.Number.ToString();
            DateO = order.DataOrder.ToString();
            PostO = order.NameOrganizationPostavshik_FK_;
            listLineOrder = new ObservableCollection<LineOrderView>(order.LineOrders);
            foreach (LineOrderView lo in listLineOrder)
            {
                summaorder += double.Parse(lo.PurchasePrice?? "0") * lo.CountOrder;
            }
            SummaOrder = summaorder.ToString() + "рублей";
            onPropertyChanged(nameof(listLineOrder));
        }


        private RelayCommand printLineOrder;

        public RelayCommand PrintLineOrder
        {
            get
            {
                return printLineOrder ??
                    (printLineOrder = new RelayCommand(obj =>
                    {
                        try
                        {

                            System.Windows.Controls.PrintDialog p = new System.Windows.Controls.PrintDialog();
                            if (p.ShowDialog() == true)
                            {
                                p.PrintVisual(LineOrder, "Печать");
                                MessageBox.Show("Заказ успешно напечатан!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommand updateLineOrder;
        public RelayCommand UpdateLineOrder
        {
            get
            {
                return updateLineOrder ??
                  (updateLineOrder = new RelayCommand(obj =>
                  {
                      try
                      {
                          LineOrderView lo = obj as LineOrderView;
                          MessageBox.Show(lo.CountOrder.ToString());
                          if (lo != null)
                          {
                              int n = listLineOrder.IndexOf(selectedLineOrder);
                              LineOrderView LOrder = new LineOrderView();
                              LOrder.CountOrder = listLineOrder[n].CountOrder;
                              LOrder.CountShipment = listLineOrder[n].CountShipment;
                              LOrder.PurchasePrice = listLineOrder[n].PurchasePrice;
                              LOrder.CodTovara_FK_ = listLineOrder[n].CodTovara_FK_;
                              LOrder.NumberOrder_FK_ = OrderView.Number;
                              LOrder.DataManuf = listLineOrder[n].DataManuf;
                              LOrder.ID = listLineOrder[n].ID;
                              dbo.UpdateLineOrder(LOrder);
                              listLineOrder.Remove(lo);
                              LoadLineOrder(OrderView);
                              if(OrderView.StatusOrder == "поставлен")
                              {
                                  var tov = dbo.GetTovar(LOrder.CodTovara_FK_);
                                  tov.Count += (int)LOrder.CountShipment;
                                  tov.DateExpiration = LOrder.DataManuf;
                                  dbo.UpdateTovar(tov);
                              }
                              MessageBox.Show("Заказ успешно изменен!");
                          }
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
