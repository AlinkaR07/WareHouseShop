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
    public class Reports1ViewModel : INotifyPropertyChanged
    {

        public string CountText { get; set; }
        public string DateText { get; set; }
        public DateTime DateWrite1 { get; set; }
        public DateTime DateWrite2 { get; set; }


        IDbCrud dbo;
        IReportsServiсе rTovar;


        public ObservableCollection<TovarView> listReports1 { get; set; }
        public ObservableCollection<TovarView> listReports2 { get; set; }
        public ObservableCollection<WriteView> listReports3 { get; set; }

        public Reports1ViewModel(IDbCrud dbcrud, IReportsServiсе report)
        {
            dbo = dbcrud;
            rTovar = report;
        }

        private RelayCommand reportCountTovar;                    //  выполнение запроса 
        public RelayCommand ReportCountTovar
        {
            get
            {
                
                return reportCountTovar ??
                  (reportCountTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                          TovarView o = new TovarView();
                          listReports1 = new ObservableCollection<TovarView>(rTovar.ExecuteSPCountTovar(int.Parse(CountText)));
                          onPropertyChanged(nameof(listReports1));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand reportAllTovar;                    //  выполнение запроса 
        public RelayCommand ReportAllTovar
        {
            get
            {

                return reportAllTovar ??
                  (reportAllTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                          TovarView o = new TovarView();
                          listReports1 = new ObservableCollection<TovarView>(dbo.GetAllTovar());
                          onPropertyChanged(nameof(listReports1));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand reportDateTovar;                        //  выполнение запроса 
        public RelayCommand ReportDateTovar
        {
            get
            {
                return reportDateTovar ??
                  (reportDateTovar = new RelayCommand(obj =>
                  {
                      try
                      {
                          TovarView o = new TovarView();
                          double d = double.Parse(DateText);
                          DateTime date = DateTime.Today;
                          date = date.AddDays(d);
                          listReports2 = new ObservableCollection<TovarView>(rTovar.ExecuteSPDateTovar(date));
                          onPropertyChanged(nameof(listReports2));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand reportDateWrite;                        //  выполнение запроса 
        public RelayCommand ReportDateWrite
        {
            get
            {
                return reportDateWrite ??
                  (reportDateWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          //TovarView o = new TovarView();
                          //double d = double.Parse(DateText);
                          //DateTime date = DateTime.Today;
                          //date = date.AddDays(d);
                          //listReports3 = new ObservableCollection<WriteView>(rTovar.ExecuteSPDateWrite(DateWrite1, DateWrite1));
                          onPropertyChanged(nameof(listReports2));
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
