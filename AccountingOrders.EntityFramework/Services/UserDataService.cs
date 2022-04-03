using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.EntityFramework.Services
{
    public class UserDataService: IUserService
    {
        private readonly AccountingOrdersDbContextFactory _contextFactory;
        private readonly GenericDataService<UserModel> _genericDataService;

        public UserDataService(AccountingOrdersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _genericDataService = new GenericDataService<UserModel>(contextFactory);
        }

        public async Task<UserModel> Create(UserModel entity)
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

        public async Task<UserModel?> Get(int id)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            UserModel? entity = await context.Set<UserModel>().Include(d => d.DepartmentModel).FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<UserModel>> Gets(int[] ids)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<UserModel> entitys = await context.Set<UserModel>().Where(e => ids.Contains(e.Id)).Include(u => u.DepartmentModel).ToListAsync();
            return entitys;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<UserModel> entity = await context.Set<UserModel>().Include(d => d.DepartmentModel).ToListAsync();
            return entity;
        }

        public async Task<UserModel?> Update(int id, UserModel entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}