using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System;
using System.Windows;
using WpfVodovoz.Data;
using WpfVodovoz.Data.Servise;
using WpfVodovoz.ViewModels;
using WpfVodovoz.Views;


namespace WpfVodovoz
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>

    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            string connectionString =
                "Server=localhost;Database=testdb;User=root;Password=1234;";

            services.AddSingleton<ISessionFactory>(
                sp => NHibernateHelper.CreateSessionFactory(connectionString));

            services.AddScoped<ISession>(
                sp => sp.GetRequiredService<ISessionFactory>().OpenSession());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<EmployeeService>();
            services.AddScoped<ContractorService>();
            services.AddScoped<OrderService>();
 
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();

            services.AddTransient<EmployeesViewModel>();
            services.AddTransient<EmployeeCreateViewModel>();
            services.AddTransient<EmployeeCreateView>();

            services.AddTransient<ContractorViewModel>();
            services.AddTransient<ContractorCreateViewModel>();
            services.AddTransient<ContractorCreateView>();

            services.AddTransient<OrderCreateViewModel>();
            services.AddTransient<OrderViewModel>();
            services.AddTransient<OrderCreateView>();


            Services = services.BuildServiceProvider();

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
