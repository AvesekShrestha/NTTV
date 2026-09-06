using NTTV.Application.Ticket.DTO;

namespace NTTV.Application.Ticket.Queue;

public interface IPoolChannelManger
{
  public PoolChannel GetChannel(Guid poolId);
  public ValueTask EnqueueAsync(Guid poolId, TicketQueueItem item, CancellationToken cancellationToken = default);
}


