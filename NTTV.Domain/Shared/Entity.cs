namespace NTTV.Domain.Shared;

public abstract class Entity<TId>(TId id) where TId : notnull
{
  public TId Id { get; protected set; } = id;

  public override bool Equals(object? obj)
  {
    if (obj is not Entity<TId> other) return false;
    return Id.Equals(other.Id);
  }

  public bool Equals(Entity<TId>? other)
  {
    return Equals(other);
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }
}
