using ScheduleWidget.Core;
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
		private ObservableCollection<object> _lessonsList;

		public ObservableCollection<object> LessonsList
		{
			get { return _lessonsList; }
			set { _lessonsList = value; NotifyPropertyChanged(); }
		}


        public EditDayViewModel()
        {
            LessonsList = new ObservableCollection<object>();
            LessonsList.Add(new object());
            LessonsList.Add(new object());
            LessonsList.Add(new object());
        }

    }
}
