using AccountingOrders.EntityFramework;
using AccountingOrders.WPF.HostBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOrders.WPF
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App() => _host = CreateHostBuilder().Build();

        public static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddViewModels()
                .AddViews();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AccountingOrdersDbContextFactory contextFactory = _host.Services.GetRequiredService<AccountingOrdersDbContextFactory>();

            using AccountingOrdersDbContext context = contextFactory.CreateDbContext();
            context.Database.Migrate();

            Window window = _host.Services.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _ = HostStopAsync();

            _host.Dispose();

            base.OnExit(e);
        }

        private async Task HostStopAsync() => await _host.StopAsync();
    }
}