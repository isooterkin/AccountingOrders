namespace AccountingOrders.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> Get(int id);

        Task<IEnumerable<T>> Gets(int[] ids);

        Task<T> Create(T entity);

        Task<T?> Update(int id, T entity);

        Task<bool> Delete(int id);

        Task<bool> Deletes(int[] ids);
    }
}