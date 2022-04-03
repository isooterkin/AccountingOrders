using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.EntityFramework
{
    public class AccountingOrdersDbContextFactory : IDesignTimeDbContextFactory<AccountingOrdersDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public AccountingOrdersDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public AccountingOrdersDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder<AccountingOrdersDbContext> options = new ();

            _configureDbContext(options);

            return new AccountingOrdersDbContext(options.Options);
        }
    }
}