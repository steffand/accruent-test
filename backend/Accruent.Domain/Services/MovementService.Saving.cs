using Accruent.Data.Interfaces;
using Accruent.Domain.Interfaces;
using Accruent.Models.Dtos;
using Accruent.Models.Entities;
using Accruent.Models.Enums;
using Microsoft.Extensions.Logging;

namespace Accruent.Domain.Services;

public sealed class MovementServiceSaving(IMovementService service, 
                                   IBaseRepository<Movement> movementRepository, 
                                   IBaseRepository<Product> productRepository,
                                   ILogger<MovementService> logger) : MovementServiceDecorator(service, logger)
{
    public override async Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        var product = productRepository.GetByFilter(p => p.Code == movement.ProductCode).FirstOrDefault();

        var movementEntity = new Movement()
        {
            ProductId = product!.Id,
            CreatedOn = DateTime.Now,
            Id = Guid.NewGuid(),
            Quantity = movement.Quantity,
            Type = (EMovementType)Enum.Parse(typeof(EMovementType), movement.Type)
        };
        await movementRepository.InsertAsync(movementEntity);
        await base.ProcessAsync(movement, cancellationToken).ConfigureAwait(false);
    }
}
