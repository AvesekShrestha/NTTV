using NTTV.Application;
using NTTV.Infrastructure;


WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddControllers();
  builder.Services.AddApplication();
  builder.Services.AddInfrastructure();
}

{

  WebApplication? app = builder.Build();
  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();

}
