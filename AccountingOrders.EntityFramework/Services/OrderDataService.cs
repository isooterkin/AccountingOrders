using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.EntityFramework.Services
{
    public class OrderDataService: IOrderService
    {
        private readonly AccountingOrdersDbContextFactory _contextFactory;
        private readonly GenericDataService<OrderModel> _genericDataService;

        public OrderDataService(AccountingOrdersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _genericDataService = new GenericDataService<OrderModel>(contextFactory);
        }

        public async Task<OrderModel> Create(OrderModel entity)
        {
            return await _genericDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericDataService.Delete(id);
        }

        public async Task<bool> Deletes(int[] ids)
        {
            return await _genericDataService.Deletes(ids);
        }

        public async Task<OrderModel?> Get(int id)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            OrderModel? entity = await context.Set<OrderModel>().Include(u => u.UserModel).FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<OrderModel>> Gets(int[] ids)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<OrderModel> entitys = await context.Set<OrderModel>().Where(e => ids.Contains(e.Id)).Include(u => u.UserModel).ToListAsync();
            return entitys;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<OrderModel> entity = await context.Set<OrderModel>().Include(u => u.UserModel).ToListAsync();
            return entity;
        }

        public async Task<OrderModel?> Update(int id, OrderModel entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}