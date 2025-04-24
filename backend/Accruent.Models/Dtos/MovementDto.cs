namespace Accruent.Models.Dtos;

public sealed class MovementDto
{
    public string ProductCode { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int Quantity { get; set; }
}
