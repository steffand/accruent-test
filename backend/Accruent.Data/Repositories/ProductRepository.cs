using Accruent.Data.Contexts;
using Accruent.Data.Interfaces;
using Accruent.Models.Entities;

namespace Accruent.Data.Repositories;

public sealed class ProductRepository(AccruentDbContext dbContext) : BaseRepository<Product>(dbContext), IBaseRepository<Product>
{
}
