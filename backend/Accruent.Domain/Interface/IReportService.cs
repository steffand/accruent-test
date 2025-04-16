using Accruent.Models.Dto;

namespace Accruent.Domain.Interface;

public interface IReportService
{
    List<ReportDto> GetReportData(DateTime movementDate, string? productCode);
}