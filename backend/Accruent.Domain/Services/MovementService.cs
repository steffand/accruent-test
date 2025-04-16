using Accruent.Models.Dto;

namespace Accruent.Domain.Services;

public class MovementService : IMovementService
{
    public Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(movement);
        return Task.CompletedTask;
    }
}
