using System.Windows;

namespace ScheduleWidget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private ServiceProvider serviceProvider;
        public App()
        {
            //ServiceCollection services = new ServiceCollection();
            //ConfigureServices(services);
            //serviceProvider = services.BuildServiceProvider();
        }
        //private void ConfigureServices(ServiceCollection services)
        //{

        //    services.AddDbContext<ApplicationDbContext>();
        //    services.AddSingleton<MainWindow>();

        //    //services.AddDbContext<EmployeeDbContext>(options =>
        //    //{
        //    //    options.UseSqlite("Data Source = Employee.db");
        //    //});
        //    //services.AddSingleton<MainWindow>();
        //}
        //private void OnStartup(object sender, StartupEventArgs eventArgs)
        //{
        //    var mainWindow = serviceProvider.GetService<MainWindow>();
        //    mainWindow.Show();
        //}
    }
}
