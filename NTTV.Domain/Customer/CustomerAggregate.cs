using NTTV.Domain.Customer.ValueObjects;
using NTTV.Domain.Shared;

namespace NTTV.Domain.Customer;

public sealed class CustomerAggregrate : AggregateRoot<Guid>
{
  public Guid UserId { get; private set; }
  public Guid DepartmentId { get; private set; }
  public PhoneNumber PhoneNumber { get; private set; }
  public Location? Location { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  private CustomerAggregrate(Guid id, Guid userId, Guid departmentId, PhoneNumber phoneNumber, Location location) : base(id)
  {
    UserId = userId;
    DepartmentId = departmentId;
    PhoneNumber = phoneNumber;
    Location = location;
  }

  public static CustomerAggregrate Create(Guid id, Guid userId, Guid departmentId, string phoneNumber, float latitude, float longitude)
  {
    return new CustomerAggregrate(id,
                                  userId,
                                  departmentId,
                                  PhoneNumber.Create(phoneNumber),
                                  Location.Create(latitude, longitude));
  }

  public void ChangeLocation(float latitude, float longititude)
  {
    Location = Location.Create(latitude, longititude);
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangePhoneNumber(string phoneNumber)
  {
    PhoneNumber = PhoneNumber.Create(phoneNumber);
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangeDepartment(Guid departmentId)
  {
    DepartmentId = departmentId;
    UpdatedAt = DateTime.UtcNow;
  }
}
