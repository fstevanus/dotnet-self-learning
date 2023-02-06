using Learning.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Learning.WebApi.Extensions;

public static class ServiceExtensions
{
  public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<RepositoryContext>(opts =>
      opts.UseSqlite(configuration.GetConnectionString("sqliteConnection")));
  }

  public static void ConfigureService(this IServiceCollection services)
  {
    services.AddScoped<IRepositoryManager, RepositoryManager>();
  }
}