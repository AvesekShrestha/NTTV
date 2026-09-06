namespace NTTV.Application.Ticket.DTO;

public sealed record TicketQueueItem(
  Guid TicketId,
  Guid PoolId
);
