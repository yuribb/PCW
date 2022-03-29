using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PCW.Data.SQLite.Hosting;
using PCW.Service.Hosting;
using ServiceCollectionExtension = PCW.Data.SQLite.Hosting.ServiceCollectionExtension;

namespace PCW.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //ServiceCollectionExtension.AddPostCardDbContext(services);
            services.AddPostCardService();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
