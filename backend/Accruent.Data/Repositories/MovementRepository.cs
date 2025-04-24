using Accruent.Data.Contexts;
using Accruent.Data.Interfaces;
using Accruent.Models.Entities;

namespace Accruent.Data.Repositories;

public sealed class MovementRepository(AccruentDbContext dbContext) : BaseRepository<Movement>(dbContext), IBaseRepository<Movement>
{
}
