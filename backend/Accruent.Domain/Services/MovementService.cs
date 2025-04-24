using Accruent.Domain.Interfaces;
using Accruent.Models.Dtos;

namespace Accruent.Domain.Services;

public sealed class MovementService : IMovementService
{
    public Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(movement);
        return Task.CompletedTask;
    }
}
