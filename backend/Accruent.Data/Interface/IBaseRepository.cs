namespace Accruent.Data.Interface;

public interface IBaseRepository<T>
{
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
    List<T> GetByFilter(Func<T, bool> filter);
    Task<List<T>> GetAllAsync(int skip = 0, CancellationToken cancellationToken = default);
}
