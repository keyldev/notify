using ScheduleWidget.Core;
using ScheduleWidget.Core.Services;
using ScheduleWidget.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.ViewModel
{
    internal class WidgetViewModel : ObservableObject
    {

        private ObservableCollection<LessonModel> _lessonsList;

        public ObservableCollection<LessonModel> LessonsList
        {
            get { return _lessonsList; }
            set { _lessonsList = value; NotifyPropertyChanged(); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }


        private readonly DayService _dayService;
        public WidgetViewModel(int dayId)
        {
            _dayService = new DayService();
            Name = _dayService.GetDayNameById(dayId);

            LessonsList = new ObservableCollection<LessonModel>(_dayService.LoadDayLessonsById(dayId));

        }
    }
}
