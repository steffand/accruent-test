using Accruent.Data.Context;
using Accruent.Data.Interface;
using Accruent.Models.Entity;

namespace Accruent.Data.Repository;

public class ProductRepository(AccruentDbContext dbContext) : BaseRepository<Product>(dbContext), IBaseRepository<Product>
{
}
