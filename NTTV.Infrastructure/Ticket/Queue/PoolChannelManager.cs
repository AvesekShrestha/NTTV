using System.Collections.Concurrent;
using NTTV.Application.Ticket.DTO;
using NTTV.Application.Ticket.Queue;

namespace NTTV.Infrastructure.Ticket.Queue;

public sealed class PoolChannelManager : IPoolChannelManger
{

  private readonly ConcurrentDictionary<Guid, PoolChannel> _channels = new();
  public ValueTask EnqueueAsync(Guid poolId, TicketQueueItem item, CancellationToken cancellationToken = default)
  {
    PoolChannel channel = GetChannel(poolId);
    return channel.EnqueueAsync(item, cancellationToken);
  }

  public PoolChannel GetChannel(Guid poolId)
  {
    return _channels.GetOrAdd(poolId, _ => new PoolChannel());
  }
}
