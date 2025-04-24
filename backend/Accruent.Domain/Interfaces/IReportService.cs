using Accruent.Models.Dtos;

namespace Accruent.Domain.Interfaces;

public interface IReportService
{
    List<ReportDto> GetReportData(DateTime movementDate, string? productCode);
}