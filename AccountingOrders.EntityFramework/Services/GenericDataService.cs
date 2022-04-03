using AccountingOrders.Domain.Models.Dependence;
using AccountingOrders.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountingOrders.EntityFramework.Services
{
    public class GenericDataService<T>: IDataService<T> where T : ObjectWithId
    {
        private readonly AccountingOrdersDbContextFactory _contextFactory;

        public GenericDataService(AccountingOrdersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            T? entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return false;
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T?> Get(int id)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            T? entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<T> entity = await context.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<T?> Update(int id, T entity)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            if (Get(id).Result == null) return null;
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}