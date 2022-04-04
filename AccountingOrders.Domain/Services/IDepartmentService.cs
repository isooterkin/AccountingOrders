using AccountingOrders.Domain.Models;

namespace AccountingOrders.Domain.Services
{
    public interface IDepartmentService: IDataService<DepartmentModel>
    {
        Task<IEnumerable<DepartmentModel>> UpdateUserIdToNull(int[] idsUser);
    }
}