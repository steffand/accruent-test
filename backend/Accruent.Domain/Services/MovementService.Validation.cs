using Accruent.Data.Interface;
using Accruent.Models.Dto;
using Accruent.Models.Entity;
using Accruent.Models.Enums;
using Accruent.Models.Exception;
using Microsoft.Extensions.Logging;

namespace Accruent.Domain.Services;

public class MovementServiceValidation(IMovementService service, 
                                       IBaseRepository<Movement> movementRepository,
                                       IBaseRepository<Product> productRepository,
                                       ILogger<MovementService> logger) : MovementServiceDecorator(service, logger)
{
    public override async Task ProcessAsync(MovementDto movement, CancellationToken cancellationToken)
    {
        var product = productRepository.GetByFilter(p => p.Code == movement.ProductCode).FirstOrDefault();

        if (product == null)
            throw new ProductNotFoundException($"Produto não encontrado {movement.ProductCode}");

        var movements = movementRepository.GetByFilter(m => m.ProductId == product.Id);

        if(movement.Type == EMovementType.Outbound.ToString() && (movements.Sum(m => m.Quantity) - Math.Abs(movement.Quantity)) < 0)
        {
            throw new InsuficientBalanceException($"Saldo do estoque: {movements.Sum(m => m.Quantity)}");
        }

        await base.ProcessAsync(movement, cancellationToken).ConfigureAwait(false);
    }
}
