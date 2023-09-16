using ScheduleWidget.Core;
using ScheduleWidget.MVVM.View;
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
        private ObservableCollection<EditDayModel> _scheduleDays;

        public ObservableCollection<EditDayModel> ScheduleDays
        {
            get { return _scheduleDays; }
            set { _scheduleDays = value; NotifyPropertyChanged(); }
        }


        #region BUTTONS_COMMAND
        public RelayCommand AddScheduleCommand { get; set; }
        public RelayCommand AddDayCommand { get; set; }
        public RelayCommand EditDayCommand { get; set; }

        public RelayCommand TurnWidget { get; set; }

        #endregion
        public MainWindowViewModel()
        {
            ScheduleDays = new ObservableCollection<EditDayModel>();

            AddScheduleCommand = new RelayCommand(o =>
            {

            });
            AddDayCommand = new RelayCommand(o => AddDay());
            EditDayCommand = new RelayCommand(o => EditDay());
            TurnWidget = new RelayCommand(o =>
            {
                WidgetWindowView widgetWindow = new WidgetWindowView();
                WidgetViewModel editWidgetViewModel = new WidgetViewModel();
                widgetWindow.DataContext = editWidgetViewModel;
                widgetWindow.Show();
            });
        }
        private void AddDay()
        {
            if (ScheduleDays.Count == 7)
                return;
            ScheduleDays.Add(new EditDayModel()
            {
                EditDayCommand = EditDayCommand
            });
        }

        private void EditDay()
        {
            EditDayViewModel editDayViewModel = new EditDayViewModel();
            EditDayWindowView editDayWindowView = new EditDayWindowView();
            editDayWindowView.DataContext = editDayViewModel;
            editDayWindowView.Owner = App.Current.MainWindow;
            editDayWindowView.ShowDialog();
        }

    }
    internal class EditDayModel
    {
        public RelayCommand EditDayCommand { get; set; }
    }
}
