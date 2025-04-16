using Accruent.Data.Interface;
using Accruent.Domain.Interface;
using Accruent.Models.Dto;
using Accruent.Models.Entity;
using Accruent.Models.Enums;

namespace Accruent.Domain.Services;

public class ReportService(IBaseRepository<Movement> movementRepository, IBaseRepository<Product> productRepository) : IReportService
{
    public List<ReportDto> GetReportData(DateTime movementDate, string? productCode)
    {
        var product = productRepository.GetByFilter(x => x.Code == productCode).FirstOrDefault();

        if (product == null && !string.IsNullOrEmpty(productCode))
            return [];

        bool filter(Movement x) => x.CreatedOn.Date == movementDate && (product == null || x.ProductId == product.Id);
        var movements = movementRepository.GetByFilter(filter);
        
        return [.. 
                    movements
                    .GroupBy(m => new { m.ProductId, m.CreatedOn.Date })
                    .Select(g => new ReportDto 
                    {
                        ProductCode = g.First().Product.Code,
                        ProductName = g.First().Product.Name,
                        Inbounds = g.Where(x => x.Type == EMovementType.Inbound).Sum(x => x.Quantity),
                        Outbounds = g.Where(x => x.Type == EMovementType.Outbound).Sum(x => x.Quantity),
                        Balance = g.Sum(x => x.Quantity)
                    })
                ];
    }
}
