namespace Accruent.Models.Exception
{
    public class ProductNotFoundException(string message) : ArgumentException(message)
    {
    }
}
