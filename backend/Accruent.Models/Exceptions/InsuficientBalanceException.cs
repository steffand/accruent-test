namespace Accruent.Models.Exceptions;

public sealed class InsuficientBalanceException(string message) : ArgumentException(message)
{
}
