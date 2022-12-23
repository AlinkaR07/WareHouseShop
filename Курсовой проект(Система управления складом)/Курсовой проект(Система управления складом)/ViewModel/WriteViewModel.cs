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
    class WriteViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        public ObservableCollection<WriteView> listWrite { get; set; }
        public ObservableCollection<LineWriteView> lineWriteViews { get; set; }
        public List<LineWriteView> AllWriteLine { get; set; }                            // для удаления строк
        public List<WriteView> AllWrite { get; set; }                            // для фильтрации
        public string Filter { get; set; }
        public WriteViewModel(IDbCrud dbcrud)
        {
            AddWriteViewModel.WriteAdd += OnWriteAdd;                                            // подписка на событие добавления заказа
            dbo = dbcrud;
            LoadWrite();
        }

        private void LoadWrite()
        {
            AllWrite = dbo.GetAllWrite();
            listWrite = new ObservableCollection<WriteView>(AllWrite);
            onPropertyChanged(nameof(listWrite));
        }

        private WriteView selectedWrite;
        public WriteView SelectedWrite
        {
            get
            {
                return selectedWrite;
            }
            set
            {
                selectedWrite = value;
                onPropertyChanged(nameof(selectedWrite));
            }
        }

        private RelayCommand removeWrite;
        public RelayCommand RemoveWrite
        {
            get
            {
                return removeWrite ??
                  (removeWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          WriteView write = obj as WriteView;
                          if (write != null)
                          {

                              dbo.DeleteWrite(write.NumberAct);
                              lineWriteViews = new ObservableCollection<LineWriteView>(AllWriteLine.Where(lw => lw.NumberActWrite_FK_ == write.NumberAct));
                              listWrite.Remove(write);
                              foreach(LineWriteView l in lineWriteViews)
                              {
                                  dbo.DeleteLineWrite(l.ID);
                              }
                              LoadWrite();
                          }
                          MessageBox.Show("Акт успешно удален!");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand updateWrite;
        public RelayCommand UpdateWrite
        {
            get
            {
                return updateWrite ??
                  (updateWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          WriteView write = obj as WriteView;
                          if (write != null)
                          {
                              int n = listWrite.IndexOf(selectedWrite);
                              WriteView w = new WriteView();
                              w.NumberAct = listWrite[n].NumberAct;
                              w.DataWrite = listWrite[n].DataWrite;
                              w.FIOworker_FK_ = listWrite[n].FIOworker_FK_;
                              dbo.UpdateWrite(w);
                              listWrite.Remove(write);
                              LoadWrite();

                              MessageBox.Show("Акт списания успешно изменен!");
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand viewWrite;
        public RelayCommand ViewWrite
        {
            get
            {
                return viewWrite ??
                  (viewWrite = new RelayCommand(obj =>
                  {
                      try
                      {
                          WriteView LWrite = obj as WriteView;
                          if (LWrite != null)
                          {
                              ViewLineWrite f = new ViewLineWrite(LWrite);
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
        private RelayCommand filterWrite;
        public RelayCommand FilterWrite
        {
            get
            {
                return filterWrite ??
                  (filterWrite = new RelayCommand(obj =>
                  {
                      try
                      {

                          listWrite = new ObservableCollection<WriteView>(AllWrite.Where(w => w.FIOworker_FK_.StartsWith(Filter)));
                          onPropertyChanged(nameof(listWrite));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private void OnWriteAdd()                                                              // функция события добавления акта списания(загрузка обновленной таблицы)
        {
            LoadWrite();
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
