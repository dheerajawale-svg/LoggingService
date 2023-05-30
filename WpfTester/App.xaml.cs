using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Natus.Logging.Client;

namespace WpfTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    //IHostEnvironment env = hostingContext.HostingEnvironment;
                    configuration.SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", 
                                              optional: false, reloadOnChange: true);

                    IConfigurationRoot configurationRoot = configuration.Build();
                })
                .ConfigureServices((hostcontext, services) =>
                {
                    services.AddHttpClient();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<INatusLogger, NatusLogger>();
                })
                .Build();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();

            base.OnExit(e);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            AppHost.Start();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
        }
    }
}
