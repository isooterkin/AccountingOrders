using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels;
using AccountingOrders.WPF.ViewsModels.Actions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccountingOrders.WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                // Главное окно
                services.AddSingleton(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

                // Окна действий
                services.AddSingleton(s => new AddDepartmentView(s.GetRequiredService<AddDepartmentViewModel>()));
                services.AddSingleton(s => new AddOrderView(s.GetRequiredService<AddOrderViewModel>()));
                services.AddSingleton(s => new AddUserView(s.GetRequiredService<AddUserViewModel>()));
                services.AddSingleton(s => new EditDepartmentView(s.GetRequiredService<EditDepartmentViewModel>()));
                services.AddSingleton(s => new EditOrderView(s.GetRequiredService<EditOrderViewModel>()));
                services.AddSingleton(s => new EditUserView(s.GetRequiredService<EditUserViewModel>()));
                services.AddSingleton(s => new ViewDepartmentView(s.GetRequiredService<ViewDepartmentViewModel>()));
                services.AddSingleton(s => new ViewOrderView(s.GetRequiredService<ViewOrderViewModel>()));
                services.AddSingleton(s => new ViewUserView(s.GetRequiredService<ViewUserViewModel>()));
            });

            return host;
        }
    }
}