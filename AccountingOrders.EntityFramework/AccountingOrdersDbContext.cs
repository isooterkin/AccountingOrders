using AccountingOrders.Domain.Models;
using AccountingOrders.EntityFramework.Converters;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.EntityFramework
{
    public class AccountingOrdersDbContext: DbContext
    {
        public DbSet<DepartmentModel>? Department { get; set; }

        public DbSet<OrderModel>? Order { get; set; }

        public DbSet<UserModel>? User { get; set; }

        public AccountingOrdersDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        }
    }
}