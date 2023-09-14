using ScheduleWidget.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public MainWindowViewModel()
        {
            CurrentView = new object();
        }


    }
}
