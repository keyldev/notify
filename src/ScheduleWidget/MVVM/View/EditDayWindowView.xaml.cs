using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScheduleWidget.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для EditDayWindowView.xaml
    /// </summary>
    public partial class EditDayWindowView : Window
    {
        public static EditDayWindowView Instance { get; private set; }

        public EditDayWindowView()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
