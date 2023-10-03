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

        private Visibility _daysPanelVisibilty = Visibility.Visible;

        public Visibility DaysPanelVisibility
        {
            get { return _daysPanelVisibilty; }
            set { _daysPanelVisibilty = value; NotifyPropertyChanged(); }
        }


        #region BUTTONS_COMMAND
        public RelayCommand AddScheduleCommand { get; set; }
        public RelayCommand AddDayCommand { get; set; }
        public RelayCommand EditDayCommand { get; set; }

        public RelayCommand LoadWidgetCommand { get; set; }

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
            ScheduleItems = new ObservableCollection<ScheduleModel>(_scheduleService.LoadSchedules());
            ScheduleDays = new ObservableCollection<DayModel>();

            foreach (var schedule in ScheduleItems)
            {
                schedule.LoadScheduleCommand = new RelayCommand(o =>
                {
                    OpenDays(schedule.Id);
                });
            }
            LoadWidgetCommand = new RelayCommand(o =>
            {
                LoadWidget(1);
            });
        }
        private void OpenDays(int id)
        {
            var days = _scheduleService.GetDaysById(id);
            ScheduleDays.Clear();

            foreach (var day in days)
            {
                day.LoadLessonsCommand = new RelayCommand(o =>
                {
                    System.Windows.MessageBox.Show(" The day id is " + day.Id);
                    EditDay(day.Id);
                });
                ScheduleDays.Add(day);
            }
        }
        private void LoadWidget(int dayId)
        {
            WidgetViewModel widgetViewModel = new WidgetViewModel(dayId);

            WidgetWindowView widgetWindow = new WidgetWindowView();
            widgetWindow.DataContext = widgetViewModel;
            widgetWindow.Show();
        }
        private void EditDay(int dayId)
        {
            EditDayViewModel editDayViewModel = new EditDayViewModel(dayId);
            //editDayViewModel.DayId = dayId;
            EditDayWindowView editDayWindowView = new EditDayWindowView();
            editDayWindowView.DataContext = editDayViewModel;
            editDayWindowView.Owner = App.Current.MainWindow;
            editDayWindowView.ShowDialog();
        }

    }

}
