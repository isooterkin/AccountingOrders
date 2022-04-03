using AccountingOrders.Domain.Models;
using AccountingOrders.EntityFramework.Services;
using AccountingOrders.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AccountingOrders.WPF.State.Navigators;

namespace AccountingOrders.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IUserService, UserDataService>();
                services.AddSingleton<IOrderService, OrderDataService>();
                services.AddSingleton<IDepartmentService, DepartmentDataService>();
                services.AddSingleton<IDataService<UserModel>, UserDataService>();
                services.AddSingleton<IDataService<OrderModel>, OrderDataService>();
                services.AddSingleton<IDataService<DepartmentModel>, DepartmentDataService>();

                services.AddSingleton<INavigator, Navigator>();
            });

            return host;
        }
    }
}