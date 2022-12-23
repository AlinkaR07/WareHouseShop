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
using System.Windows;
using System.Windows.Controls;

namespace Курсовой_проект_Система_управления_складом_.ViewModel
{
    public class LineWriteViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        IReportsServiсе rWrite;

        Grid LineWrite;

        public string NumberW { get; set; }
        public string DateW { get; set; }
        public string WorkerW { get; set; }
        public string SummaWrite { get; set; }
        public ObservableCollection<LineWriteView> listLineWrite { get; set; }
        public LineWriteViewModel(IDbCrud dbcrud, WriteView write, IReportsServiсе repos, Grid line)
        {
            dbo = dbcrud;
            rWrite = repos;
            LineWrite = line;
            LoadLineWrite(write);
        }
        private void LoadLineWrite(WriteView write)
        {
            double summawrite=0;
            int Number = write.NumberAct;
            NumberW = write.NumberAct.ToString();
            DateW = write.DataWrite.ToString();
            WorkerW = write.FIOworker_FK_;
            listLineWrite = new ObservableCollection<LineWriteView>(write.LineWrites);
            foreach (LineWriteView lw in listLineWrite)
            {
                summawrite += lw.Summa;
            }
            SummaWrite = summawrite.ToString() + "рублей";
        }

        private RelayCommand printLineWrite;

        public RelayCommand PrintLineWrite
        {
            get
            {
                return printLineWrite ??
                    (printLineWrite = new RelayCommand(obj =>
                    {
                        try
                        {

                            System.Windows.Controls.PrintDialog p = new System.Windows.Controls.PrintDialog();
                            if (p.ShowDialog() == true)
                            {
                                p.PrintVisual(LineWrite, "Печать");
                                MessageBox.Show("Акт списания успешно напечатан!");
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
