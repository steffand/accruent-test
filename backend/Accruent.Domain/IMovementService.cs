using Accruent.Models.Dto;

namespace Accruent.Domain;

public interface IMovementService
{
    Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken);
}
