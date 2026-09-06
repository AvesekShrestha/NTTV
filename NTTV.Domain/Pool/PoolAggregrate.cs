using NTTV.Domain.Pool.Enums;
using NTTV.Domain.Pool.Exceptions;
using NTTV.Domain.Shared;

namespace NTTV.Domain.Pool;

public sealed class PoolAggregrate : AggregateRoot<Guid>
{

  private readonly List<Guid> _agentIds = new();

  public PoolCategory Category { get; private set; }
  public IReadOnlyCollection<Guid> Agents => _agentIds.AsReadOnly();

  private PoolAggregrate(Guid id, PoolCategory category) : base(id)
  {
    Category = category;
  }

  public static PoolAggregrate Create(Guid id, PoolCategory category)
  {
    return new PoolAggregrate(id, category);
  }

  public void AddAgent(Guid agentId)
  {
    if (_agentIds.Contains(agentId))
    {
      throw new AgentAlreadyInPoolException($"Agent with ID {agentId} is already in the pool");
    }
    _agentIds.Add(agentId);
  }

  public void RemoveAgent(Guid agentId)
  {
    if (!_agentIds.Contains(agentId))
    {
      throw new AgentNotfoundInPoolException($"Agent with ID {agentId} not found in the pool");
    }
    _agentIds.Remove(agentId);
  }

}
