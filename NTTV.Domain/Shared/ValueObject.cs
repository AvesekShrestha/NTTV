namespace NTTV.Domain.Shared;

public abstract class ValueObject
{
  protected abstract IEnumerable<object> GetEqualityComponents();

  public override bool Equals(object? obj)
  {
    if (obj is not ValueObject other || other.GetType() != GetType()) return false;
    return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
  }

  public bool Equals(ValueObject? other)
  {
    if (other is null || other.GetType() != GetType()) return false;
    return Equals(other);
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents().Aggregate(0, (hash, value) => HashCode.Combine(hash, value?.GetHashCode() ?? 0));
  }
}
