using Accruent.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Accruent.Data.Repositories;

public abstract class BaseRepository<T>(AccruentDbContext dbContext) where T : class
{
    private const int MAX_PER_PAGE = 10;
    public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null) 
            throw new ArgumentNullException(nameof(entity));

        dbContext.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public List<T> GetByFilter(Func<T, bool> filter)
    {
        return dbContext.Set<T>().Where(filter).ToList();
    }

    public async Task<List<T>> GetAllAsync(int skip = 0, CancellationToken cancellationToken = default)
    {
        var result = dbContext.Set<T>();

        if(skip > 0)
            result.Take(MAX_PER_PAGE).Skip(skip);

        return await result.ToListAsync(cancellationToken);
    }
}
