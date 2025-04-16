using Accruent.Models.Dto;
using Microsoft.Extensions.Logging;

namespace Accruent.Domain.Services;

public class MovementServiceDecorator(IMovementService service, ILogger<MovementService> logger) : IMovementService
{
    public virtual async Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(movement);
        try
        {
            await service.ProcessAsync(movement, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error processing {param} {class}", nameof(ProcessAsync), nameof(MovementServiceDecorator));
            throw;
        }
    }
}
