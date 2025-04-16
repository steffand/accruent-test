using Accruent.Data.Context;
using Accruent.Data.Interface;
using Accruent.Models.Entity;

namespace Accruent.Data.Repository;

public class MovementRepository(AccruentDbContext dbContext) : BaseRepository<Movement>(dbContext), IBaseRepository<Movement>
{
}
