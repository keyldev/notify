using ScheduleWidget.Core;
using ScheduleWidget.Core.Services;
using ScheduleWidget.MVVM.Model;
using ScheduleWidget.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.ViewModel
{
    class EditDayViewModel : ObservableObject
    {
        private ObservableCollection<LessonModel> _lessonsList;

        public ObservableCollection<LessonModel> LessonsList
        {
            get { return _lessonsList; }
            set { _lessonsList = value; NotifyPropertyChanged(); }
        }

        private int _dayId;

        public int DayId
        {
            get { return _dayId; }
            set { _dayId = value; NotifyPropertyChanged(); }
        }
        private string _dayName;

        public string DayName
        {
            get { return _dayName; }
            set { _dayName = value; NotifyPropertyChanged(); }
        }

        public RelayCommand SaveLessonsCommand { get; set; }
        public RelayCommand AddNewLessonCommand { get; set; }

        private readonly DayService _dayService;
        public EditDayViewModel(int dayId)
        {
            _dayService = new DayService();
            DayId = dayId;
            DayName = _dayService.GetDayNameById(dayId);

            LessonsList = new ObservableCollection<LessonModel>(_dayService.LoadDayLessonsById(DayId));
            AddNewLessonCommand = new RelayCommand(o =>
            {
                LessonsList.Add(new LessonModel() { DayId = DayId, Number = LessonsList.Count });
            });
            SaveLessonsCommand = new RelayCommand(o =>
            {
                _dayService.SaveLessons(LessonsList.ToList());
                EditDayWindowView.Instance.Close();
            });


        }

    }
}
