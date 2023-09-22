using ScheduleWidget.Core;
using ScheduleWidget.Core.Data;
using ScheduleWidget.MVVM.Model;
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
        public MainWindowViewModel()
        {
            ScheduleDays = new ObservableCollection<EditDayModel>();
            ScheduleItems = new ObservableCollection<ScheduleModel>();
            ScheduleItems.CollectionChanged += ScheduleItems_CollectionChanged;

            AddScheduleCommand = new RelayCommand(o =>
            {
                AddSchedule();
            });
            AddDayCommand = new RelayCommand(o => AddDay(_guidTest));
            //EditDayCommand = new RelayCommand(o => EditDay());
            TurnWidget = new RelayCommand(o =>
            {
                WidgetWindowView widgetWindow = new WidgetWindowView();
                WidgetViewModel editWidgetViewModel = new WidgetViewModel();
                widgetWindow.DataContext = editWidgetViewModel;
                widgetWindow.Show();
            });
        }

        private void AddSchedule()
        {
            using (var db = new ApplicationDbContext())
            {
                var schedule = new ScheduleModel()
                {
                    Id = Guid.NewGuid(),
                    Days = new List<DayModel>(),
                    IsEvenWeek = true,
                    Name = "Schedule " + db.Schedules.Count(),
                };
                db.Schedules.Add(schedule);
                db.SaveChanges();

                // fix it, kostyl ili net
                schedule.LoadScheduleCommand = new RelayCommand(o => { LoadScheduleDays(schedule.Id); });
                _guidTest = schedule.Id;
                ScheduleItems.Add(schedule);

            }
        }
        private Guid _guidTest;

        private void LoadScheduleDays(Guid scheduleId)
        {
            using (var db = new ApplicationDbContext())
            {
                var scheduleDays = db.Days.Where(d => d.ScheduleId == scheduleId).ToList();
                if (scheduleDays is not null)
                {
                    foreach (var day in scheduleDays)
                    {
                        ScheduleDays.Add(new EditDayModel
                        {
                            DayId = day.Id,
                            DayName = day.Name,
                            EditDayCommand = new RelayCommand(o =>
                            {

                                EditDay(day.Id);
                            })
                        });
                    }
                }
            }
        }

        private void ScheduleItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DaysPanelVisibility = (ScheduleItems.Count > 0 ? Visibility.Visible : Visibility.Collapsed);
        }

        private void AddDay(Guid scheduleId)
        {
            if (ScheduleDays.Count == 7)
                return;

            using (var db = new ApplicationDbContext())
            {
                var days = db.Days.Where(d => d.ScheduleId == scheduleId).ToList();
                if(days is not null && days.Count < 7)
                {
                    var day = new DayModel()
                    {
                        Id = Guid.NewGuid(),
                        ScheduleId = scheduleId,
                        Name = "Monday",
                    };
                }
            }

            ScheduleDays.Add(new EditDayModel()
            {
                EditDayCommand = EditDayCommand
            });
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
    internal class EditDayModel
    {
        public Guid DayId { get; set; }
        public string? DayName { get; set; }
        public string DayDescription { get; set; }

        public RelayCommand EditDayCommand { get; set; }
    }
}
