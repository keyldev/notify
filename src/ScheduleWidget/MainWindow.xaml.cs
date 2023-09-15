using ScheduleWidget.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            taskBarIcon.LeftClickCommand = new RelayCommand(o =>
            {
                if (WindowState == WindowState.Minimized)
                {
                    WindowState = WindowState.Normal;

                }
                else
                {
                    WindowState = WindowState.Minimized;
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //test.Items.Add(new object());
        }
    }
}
