using Accruent.Models.Enums;

namespace Accruent.Models.Entities;

public sealed class Movement
{
    public Guid Id { get; set; }
    public Guid ProductId {  get; set; } = default!;
    public EMovementType Type { get; set; }
    public DateTime CreatedOn { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = default!;
}
