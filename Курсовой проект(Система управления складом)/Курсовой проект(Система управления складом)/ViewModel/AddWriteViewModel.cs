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
    class AddWriteViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        Border Write;

        public static Action WriteAdd;                           // событие на добавление поставщика в таблицу поставщиков
        public string FIOWorker { get; set; }
        public DateTime DateWrite { get; set; }
        public int Count { get; set; }
        public int Summa { get; set; }
        public int CodTovara { get; set; }
        public ObservableCollection<TovarView> listComboboxTovar { get; set; }
        public ObservableCollection<LineWriteView> listLineWrite { get; set; }
        public AddWriteViewModel(IDbCrud dbcrud, Border write)
        {
            dbo = dbcrud;
            LoadComboboxTovar();
            FIOWorker = "Прокофьева Е.И.";
            Write = write;
            DateWrite= DateTime.Today;
            listLineWrite = new ObservableCollection<LineWriteView> { new LineWriteView { } };
        }

        private RelayCommand addWrite;
        public RelayCommand AddWrite
        {
            get
            {
                return addWrite ??
                  (addWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          WriteView w = new WriteView();
                          w.DataWrite = DateWrite;
                          w.FIOworker_FK_ = FIOWorker;
                          dbo.CreateWrite(w);
                          WriteView write = dbo.GetAllWrite().Last();
                          foreach (LineWriteView l in listLineWrite)
                          {
                              l.NumberActWrite_FK_= write.NumberAct;
                              TovarView t = dbo.GetTovar(l.CodTovara_FK_);
                              l.Summa = l.Count * t.Price;
                              dbo.CreateLineWrite(l);
                              t.Count -= l.Count;
                              dbo.UpdateTovar(t);
                          }
                          MessageBox.Show("Акт успешно добавлен!");
                          WriteAdd?.Invoke();                                       // реакция на добавление нового поставщика
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        // команда печати
        private RelayCommand printWrite;
        public RelayCommand PrintWrite
        {
            get
            {
                return printWrite ??
                  (printWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          PrintDialog p = new PrintDialog();
                          if (p.ShowDialog() == true)
                          {
                              p.PrintVisual(Write, "Печать");
                          }
                          MessageBox.Show("Акт успешно напечатан!");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        public void LoadComboboxTovar()
        {
            listComboboxTovar = new ObservableCollection<TovarView>(dbo.GetAllTovar().Where(t => t.DateExpiration <= DateTime.Today && t.Count !=0));
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
