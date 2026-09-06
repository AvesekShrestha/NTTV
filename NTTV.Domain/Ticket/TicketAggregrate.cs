using NTTV.Domain.Shared;
using NTTV.Domain.Ticket.Enums;

namespace NTTV.Domain.Ticket;

public sealed class TicketAggregrate : AggregateRoot<Guid>
{

  public string Description { get; private set; }
  public TicketStatus Status { get; private set; }
  public TicketAssignmentStatus AssignmentStatus { get; private set; } = TicketAssignmentStatus.UNASSIGNED;
  public Guid AgentId { get; private set; }
  public Guid DepartmentId { get; private set; }
  public Guid CustomerId { get; private set; }



  private TicketAggregrate(Guid id) : base(id)
  {

  }

  public static TicketAggregrate Create(Guid id, )
  {
    return new TicketAggregrate(id);

  }






}

