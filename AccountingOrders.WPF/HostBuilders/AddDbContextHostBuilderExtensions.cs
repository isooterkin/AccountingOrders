using AccountingOrders.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AccountingOrders.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("MSSQL");
                void configureDbContext(DbContextOptionsBuilder o) => o.UseSqlServer(connectionString);
                services.AddDbContext<AccountingOrdersDbContext>(configureDbContext);
                services.AddSingleton(new AccountingOrdersDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}