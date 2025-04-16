namespace Accruent.Models.Exception
{
    public class InsuficientBalanceException(string message) : ArgumentException(message)
    {
    }
}
