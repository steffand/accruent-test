using Accruent.Models.Dtos;

namespace Accruent.Domain.Interfaces;

public interface IMovementService
{
    Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken);
}
