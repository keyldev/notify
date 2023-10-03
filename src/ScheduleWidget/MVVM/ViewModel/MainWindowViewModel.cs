using ScheduleWidget.Core;
using ScheduleWidget.Core.Data;
using ScheduleWidget.Core.Services;
using ScheduleWidget.MVVM.Model;
using ScheduleWidget.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ScheduleWidget.MVVM.ViewModel
{
    internal class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<DayModel> _scheduleDays;

        public ObservableCollection<DayModel> ScheduleDays
        {
            get { return _scheduleDays; }
            set { _scheduleDays = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<ScheduleModel> _ScheduleItems;

        public ObservableCollection<ScheduleModel> ScheduleItems
        {
            get { return _ScheduleItems; }
            set
            {
                _ScheduleItems = value; NotifyPropertyChanged();
            }
        }

        private Visibility _daysPanelVisibilty = Visibility.Collapsed;

        public Visibility DaysPanelVisibility
        {
            get { return _daysPanelVisibilty; }
            set { _daysPanelVisibilty = value; NotifyPropertyChanged(); }
        }


        #region BUTTONS_COMMAND
        public RelayCommand AddScheduleCommand { get; set; }
        public RelayCommand AddDayCommand { get; set; }
        public RelayCommand EditDayCommand { get; set; }

        public RelayCommand TurnWidget { get; set; }

        #endregion

        private ScheduleModel _schedule;
        public ScheduleModel Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                NotifyPropertyChanged();
            }
        }


        private readonly ScheduleService _scheduleService;
        public MainWindowViewModel()
        {
            _scheduleService = new ScheduleService();

            ScheduleDays = new ObservableCollection<DayModel>();
            ScheduleItems = new ObservableCollection<ScheduleModel>();

            

        }

        private void ScheduleItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DaysPanelVisibility = (ScheduleItems.Count > 0 ? Visibility.Visible : Visibility.Collapsed);
        }
        private void EditDay(Guid dayId)
        {
            EditDayViewModel editDayViewModel = new EditDayViewModel();
            EditDayWindowView editDayWindowView = new EditDayWindowView();
            editDayWindowView.DataContext = editDayViewModel;
            editDayWindowView.Owner = App.Current.MainWindow;
            editDayWindowView.ShowDialog();
        }

    }
   
}
