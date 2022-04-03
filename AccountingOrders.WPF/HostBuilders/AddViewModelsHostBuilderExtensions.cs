using AccountingOrders.WPF.ViewsModels;
using AccountingOrders.WPF.ViewsModels.Actions;
using AccountingOrders.WPF.ViewsModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AccountingOrders.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                // Главное окно
                services.AddTransient<MainViewModel>();

                // Таблицы
                services.AddTransient<UserViewModel>();
                services.AddTransient<OrderViewModel>();
                services.AddTransient<DepartmentViewModel>();

                // Окна действий
                services.AddTransient<AddDepartmentViewModel>();
                services.AddTransient<AddOrderViewModel>();
                services.AddTransient<AddUserViewModel>();
                services.AddTransient<EditDepartmentViewModel>();
                services.AddTransient<EditOrderViewModel>();
                services.AddTransient<EditUserViewModel>();
                services.AddTransient<ViewDepartmentViewModel>();
                services.AddTransient<ViewOrderViewModel>();
                services.AddTransient<ViewUserViewModel>();

                // Таблицы
                services.AddSingleton<CreateViewModel<DepartmentViewModel>>(services => () => services.GetRequiredService<DepartmentViewModel>());
                services.AddSingleton<CreateViewModel<OrderViewModel>>(services => () => services.GetRequiredService<OrderViewModel>());
                services.AddSingleton<CreateViewModel<UserViewModel>>(services => () => services.GetRequiredService<UserViewModel>());

                // Окна действий
                services.AddSingleton<CreateViewModel<AddDepartmentViewModel>>(services => () => services.GetRequiredService<AddDepartmentViewModel>());
                services.AddSingleton<CreateViewModel<AddOrderViewModel>>(services => () => services.GetRequiredService<AddOrderViewModel>());
                services.AddSingleton<CreateViewModel<AddUserViewModel>>(services => () => services.GetRequiredService<AddUserViewModel>());
                services.AddSingleton<CreateViewModel<EditDepartmentViewModel>>(services => () => services.GetRequiredService<EditDepartmentViewModel>());
                services.AddSingleton<CreateViewModel<EditOrderViewModel>>(services => () => services.GetRequiredService<EditOrderViewModel>());
                services.AddSingleton<CreateViewModel<EditUserViewModel>>(services => () => services.GetRequiredService<EditUserViewModel>());
                services.AddSingleton<CreateViewModel<ViewDepartmentViewModel>>(services => () => services.GetRequiredService<ViewDepartmentViewModel>());
                services.AddSingleton<CreateViewModel<ViewOrderViewModel>>(services => () => services.GetRequiredService<ViewOrderViewModel>());
                services.AddSingleton<CreateViewModel<ViewUserViewModel>>(services => () => services.GetRequiredService<ViewUserViewModel>());

                // Фабрика
                services.AddSingleton<IAccountingOrdersViewModelFactory, AccountingOrdersViewModelFactory>();
                services.AddSingleton<IAccountingOrdersViewFactory, AccountingOrdersViewFactory>();
            });

            return host;
        }
    }
}