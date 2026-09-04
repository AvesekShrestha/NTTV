using Microsoft.Extensions.DependencyInjection;
using NTTV.Application.Common.Interfaces;
using NTTV.Infrastructure.Identity;


namespace NTTV.Infrastructure;


public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddScoped<IIdGenerator, IdGenerator>();
    return services;
  }
}
