using NTTV.Domain.Customer.ValueObjects;
using NTTV.Domain.Shared;

namespace NTTV.Domain.Department;

public sealed class DepartmentAggregate : AggregateRoot<Guid>
{
  public string Name { get; private set; }
  public Location Location { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;


  private DepartmentAggregate(Guid id, string name, Location location) : base(id)
  {
    Id = id;
    Name = name;
    Location = location;
  }

  public static DepartmentAggregate Create(Guid id, string name, float latitude, float longitude)
  {
    if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Department name can't be empty");
    return new DepartmentAggregate(id, name, Location.Create(latitude, longitude));
  }

  public void ChangeLocation(float latitude, float longitude)
  {
    Location = Location.Create(latitude, longitude);
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangeName(string name)
  {
    Name = name;
    UpdatedAt = DateTime.UtcNow;
  }
}
