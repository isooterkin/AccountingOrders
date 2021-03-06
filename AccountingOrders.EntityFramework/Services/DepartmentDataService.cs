using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.EntityFramework.Services
{
    public class DepartmentDataService: IDepartmentService
    {
        private readonly AccountingOrdersDbContextFactory _contextFactory;
        private readonly GenericDataService<DepartmentModel> _genericDataService;

        public DepartmentDataService(AccountingOrdersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _genericDataService = new GenericDataService<DepartmentModel>(contextFactory);
        }

        public async Task<DepartmentModel> Create(DepartmentModel entity)
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

        public async Task<DepartmentModel?> Get(int id)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            DepartmentModel? entity = await context.Set<DepartmentModel>().Include(u => u.UserModel).FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<DepartmentModel>> Gets(int[] ids)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<DepartmentModel> entitys = await context.Set<DepartmentModel>().Where(e => ids.Contains(e.Id)).Include(u => u.UserModel).ToListAsync();
            return entitys;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAll()
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<DepartmentModel> entity = await context.Set<DepartmentModel>().Include(u => u.UserModel).ToListAsync();
            return entity;
        }

        public async Task<DepartmentModel?> Update(int id, DepartmentModel entity)
        {
            return await _genericDataService.Update(id, entity);
        }

        public async Task<IEnumerable<DepartmentModel>> UpdateUserIdToNull(int[] idsUser)
        {
            using AccountingOrdersDbContext context = _contextFactory.CreateDbContext();
            #pragma warning disable CS8629 // Тип значения, допускающего NULL, может быть NULL.
            List<DepartmentModel> entity = await context.Set<DepartmentModel>().Where(e => idsUser.Contains((int)e.UserId)).ToListAsync();
            #pragma warning restore CS8629 // Тип значения, допускающего NULL, может быть NULL.
            entity.ForEach(a => a.UserId = null);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}