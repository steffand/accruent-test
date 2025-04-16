using Accruent.Models.Enums;

namespace Accruent.Models.Dto;

public class MovementDto
{
    public string ProductCode { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int Quantity { get; set; }
}
