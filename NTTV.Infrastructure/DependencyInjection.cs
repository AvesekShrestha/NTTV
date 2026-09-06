using Microsoft.Extensions.DependencyInjection;
using NTTV.Application.Common.Interfaces;
using NTTV.Application.Ticket.Queue;
using NTTV.Infrastructure.Identity;
using NTTV.Infrastructure.Ticket.Queue;


namespace NTTV.Infrastructure;


public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddSingleton<IIdGenerator, IdGenerator>();
    services.AddSingleton<IPoolChannelManger, PoolChannelManager>();

    return services;
  }
}
