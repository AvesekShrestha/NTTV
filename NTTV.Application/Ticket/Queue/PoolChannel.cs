using System.Threading.Channels;
using NTTV.Application.Ticket.DTO;

namespace NTTV.Application.Ticket.Queue;

public sealed class PoolChannel
{
  private readonly Channel<TicketQueueItem> _channel;

  public PoolChannel()
  {
    _channel = Channel.CreateBounded<TicketQueueItem>(new BoundedChannelOptions(100)
    {
      SingleWriter = true,
      SingleReader = true
    });
  }

  public ValueTask EnqueueAsync(TicketQueueItem item, CancellationToken cancellationToken = default)
  {
    return _channel.Writer.WriteAsync(item, cancellationToken);
  }
  public ValueTask<TicketQueueItem> DequeueAsync(CancellationToken token = default)
  {
    return _channel.Reader.ReadAsync(token);
  }
}
