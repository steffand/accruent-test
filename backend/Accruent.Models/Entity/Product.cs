namespace Accruent.Models.Entity;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public List<Movement> Movements { get; set; }
}
