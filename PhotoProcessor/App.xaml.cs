using System.Configuration;
using System.Data;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using PhotoProcessor.Services;
using PhotoProcessor.ViewModels;

namespace PhotoProcessor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; }
            = BuildServiceProvider();

        private static IServiceProvider BuildServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowModel>();

            services.AddSingleton<ToolsManager>();

            services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Services
                .GetRequiredService<MainWindow>()
                .Show();

            base.OnStartup(e);
        }
    }

}
