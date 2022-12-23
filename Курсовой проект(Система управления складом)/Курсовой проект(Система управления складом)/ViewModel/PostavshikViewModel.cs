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
using System.Windows;
using Курсовой_проект_Система_управления_складом_.View;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    class PostavshikViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        public ObservableCollection<PostavshikView> listPostavshik { get; set; }
        public List<PostavshikView> AllPostavshik { get; set; }                                   // для печати

        public string Filter { get; set; }
        public PostavshikViewModel(IDbCrud dbcrud)
        {
            AddPostavshikViewModel.PostavshikAdd += OnPostavshikAdd;                                            // подписка на событие добавления поставщика
            dbo = dbcrud;
            LoadPostavshiki();
        }

        private void LoadPostavshiki()
        {
            AllPostavshik = dbo.GetAllPostavshiki();
            listPostavshik = new ObservableCollection<PostavshikView>(AllPostavshik);
            onPropertyChanged(nameof(listPostavshik));
        }

        private PostavshikView selectedPostavshik;
        public PostavshikView SelectedPostavshik
        {
            get
            {
                return selectedPostavshik;
            }
            set
            {
                selectedPostavshik = value;
                onPropertyChanged(nameof(selectedPostavshik));
            }
        }

        private RelayCommand removePostavshik;
        public RelayCommand RemovePostavshik
        {
            get
            {
                return removePostavshik ??
                  (removePostavshik = new RelayCommand(obj =>
                  {
                      try
                      {
                          PostavshikView postavshik = obj as PostavshikView;
                          if (postavshik != null)
                          {

                              dbo.DeletePostavshik(postavshik.NameOrganization);
                              listPostavshik.Remove(postavshik);
                              LoadPostavshiki();
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

        private RelayCommand updatePostavshik;
        public RelayCommand UpdatePostavshik
        {
            get
            {
                return updatePostavshik ??
                  (updatePostavshik = new RelayCommand(obj =>
                  {
                      try
                      {
                          PostavshikView postavshik = obj as PostavshikView;
                          if (postavshik != null)
                          { 
                              int n = listPostavshik.IndexOf(selectedPostavshik);
                              PostavshikView p = new PostavshikView();
                              p.NameOrganization = listPostavshik[n].NameOrganization;
                              p.FIOdirector= listPostavshik[n].FIOdirector;
                              p.INN = listPostavshik[n].INN;
                              p.NumberAccount = listPostavshik[n].NumberAccount;
                              dbo.UpdatePostavshik(p);
                              listPostavshik.Remove(postavshik);
                              LoadPostavshiki();

                              MessageBox.Show("Поставщик успешно изменен!");
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand filterPostavshik;
        public RelayCommand FilterPostavshik
        {
            get
            {
                return filterPostavshik ??
                  (filterPostavshik = new RelayCommand(obj =>
                  {
                      try
                      {
                          listPostavshik = new ObservableCollection<PostavshikView>(AllPostavshik.Where(p => p.NameOrganization.StartsWith(Filter)));
                          onPropertyChanged(nameof(listPostavshik));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        private void OnPostavshikAdd()                                                              // функция события добавления поставщика(загрузка обновленной таблицы)
        {
            LoadPostavshiki();
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
