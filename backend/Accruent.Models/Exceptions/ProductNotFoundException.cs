namespace Accruent.Models.Exceptions;

public sealed class ProductNotFoundException(string message) : ArgumentException(message)
{
}
