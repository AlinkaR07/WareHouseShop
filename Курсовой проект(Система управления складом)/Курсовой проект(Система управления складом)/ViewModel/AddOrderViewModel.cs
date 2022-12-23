using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.ObjectModel;
using Курсовой_проект_Система_управления_складом_.View;
using System.Windows;
using System.Reflection.Metadata;


namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class AddOrderViewModel : INotifyPropertyChanged
    {
        Grid order;

        public static Action OrderAdd;                           // событие на добавление заказа в таблицу заказов
        public string FIOWorker { get; set; }
        public string Postavshik { get; set; }
        public DateTime DateOrder { get; set; }
        public string CodTovara { get; set; }
       

        IDbCrud dbo;
        public ObservableCollection<PostavshikView> listComboboxPost { get; set; }
        public ObservableCollection<LineOrderView> listLineOrder { get; set; }
        public ObservableCollection<TovarView> listComboboxTovar { get; set; }
        public AddOrderViewModel(IDbCrud dbcrud, Grid Order)
        {
            dbo = dbcrud;
            LoadComboboxPost();
            LoadComboboxTovar();
            FIOWorker = "Прокофьева Е.И.";
            order = Order;
            DateOrder = DateTime.Today;
            listLineOrder = new ObservableCollection<LineOrderView>();
        }

        private RelayCommand addOrder;
        public RelayCommand AddOrder
        {
            get
            {
                return addOrder ??
                  (addOrder = new RelayCommand(obj =>
                  {
                      try
                      {
                          OrderView o = new OrderView();                                          // + добавление заказа в таблицу
                          o.DataOrder = DateOrder;
                          o.StatusOrder = "сформирован";
                          o.NameOrganizationPostavshik_FK_ = Postavshik;
                          o.FIOworker_FK_ = FIOWorker;
                          dbo.CreateOrder(o);
                          OrderView order = dbo.GetAllOrder().Last();
                          foreach (LineOrderView l in listLineOrder)
                          {
                              l.NumberOrder_FK_ = order.Number;
                              dbo.CreateLineOrder(l);
                          }
                          MessageBox.Show("Заказ успешно сформирован!");
                          OrderAdd?.Invoke();                                          // реакция на добавление нового заказа
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand printOrder;

        public RelayCommand PrintOrder
        {
            get
            {
                return printOrder ??
                    (printOrder = new RelayCommand(obj =>
                    {
                        try
                        {

                            System.Windows.Controls.PrintDialog p = new System.Windows.Controls.PrintDialog();
                            if (p.ShowDialog() == true)
                            {
                                p.PrintVisual(order, "Печать");
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

        public void LoadComboboxPost()
        {
            listComboboxPost = new ObservableCollection<PostavshikView>(dbo.GetAllPostavshiki());
            
        }

        public void LoadComboboxTovar()
        {
            listComboboxTovar = new ObservableCollection<TovarView>(dbo.GetAllTovar());
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
