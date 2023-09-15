using ScheduleWidget.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleWidget.MVVM.ViewModel
{
    internal class MainWindowViewModel : ObservableObject
    {

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<string> _ScheduleItems;

        public ObservableCollection<string> ScheduleItems
        {
            get { return _ScheduleItems; }
            set { _ScheduleItems = value; NotifyPropertyChanged(); }
        }

        public RelayCommand AddItemCommand { get; set; }
        public MainWindowViewModel()
        {
            CurrentView = new object();
            ScheduleItems = new ObservableCollection<string>();

            AddItemCommand = new RelayCommand(o =>
            {

                ScheduleItems.Add("dura dora");
            });

        }


    }
}
