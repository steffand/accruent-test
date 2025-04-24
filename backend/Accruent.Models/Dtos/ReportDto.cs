namespace Accruent.Models.Dtos;

public sealed class ReportDto
{
    public string ProductName { get; set; } = default!;
    public string ProductCode { get; set; } = default!;
    public int Inbounds { get; set; }
    public int Outbounds { get; set; }
    public int Balance { get; set; }
}
