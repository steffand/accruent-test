using Accruent.Domain.Interfaces;
using Accruent.Models.Dtos;
using Accruent.Models.Enums;
using Microsoft.Extensions.Logging;

namespace Accruent.Domain.Services;

public sealed class MovementServiceProcess(IMovementService service, ILogger<MovementService> logger) : MovementServiceDecorator(service, logger)
{
    public override async Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        if(movement.Type == EMovementType.Outbound.ToString())
        {
            movement.Quantity = movement.Quantity * (movement.Quantity > 0 ? -1 : 1);
        }

        await base.ProcessAsync(movement, cancellationToken).ConfigureAwait(false);
    }
}
