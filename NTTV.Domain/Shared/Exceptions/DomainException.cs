namespace NTTV.Domain.Shared.Exceptions;

public abstract class DomainException(string message, int status) : Exception(message)
{
  public int Status { get; } = status;
}
