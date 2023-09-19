using ScheduleWidget.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(AppDomain.CurrentDomain.BaseDirectory + "/icon.ico");
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += (s, e) => {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // Показываем окно приложения
                    this.Show();
                    this.WindowState = WindowState.Normal;
                }
            };
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
