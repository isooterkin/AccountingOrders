using AccountingOrders.Domain.Models;

namespace AccountingOrders.Domain.Services
{
    public interface IUserService: IDataService<UserModel>
    {
        Task<IEnumerable<UserModel>> UpdateDepartmentIdToNull(int[] idsDepartment);
    }
}