using NTTV.Domain.Agent.Enums;
using NTTV.Domain.Shared;

namespace NTTV.Domain.Agent;

public sealed class AgentAggregrate : AggregateRoot<Guid>
{

  public Guid UserId { get; private set; }
  public Guid DepartmentId { get; private set; }
  public AgentLevel Level { get; private set; }
  public AgentAvailability Availability { get; private set; }
  public int Capacity { get; private set; } = 10;
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  private AgentAggregrate(Guid id, Guid userId, Guid departmentId, AgentLevel level, AgentAvailability availability, int capacity) : base(id)
  {
    UserId = userId;
    DepartmentId = departmentId;
    Level = level;
    Availability = availability;
    Capacity = capacity;
  }

  public static AgentAggregrate Create(Guid id, Guid userId, Guid departmentId, AgentLevel level, AgentAvailability availability, int capacity)
  {
    return new AgentAggregrate(id,
                               userId,
                               departmentId,
                               level,
                               availability,
                               capacity);
  }

  public void ChangeDepartment(Guid departmentId)
  {
    DepartmentId = departmentId;
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangeLevel(AgentLevel level)
  {
    Level = level;
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangeAvailability(AgentAvailability availability)
  {
    Availability = availability;
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangeCapacity(int capacity)
  {
    Capacity = capacity;
    UpdatedAt = DateTime.UtcNow;
  }
}
