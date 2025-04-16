using Accruent.Domain.Interface;
using Accruent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Accruent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController(IReportService reportService) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ReportDto> Get(DateTime movementDate, string? productCode, CancellationToken cancellationToken)
        {
            return reportService.GetReportData(movementDate, productCode);
        }
    }
}
