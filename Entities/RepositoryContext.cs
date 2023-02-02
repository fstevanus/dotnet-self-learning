using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Learning.Entities
{
  public class RepositoryContext : DbContext
  {
    public RepositoryContext(DbContextOptions options) : base(options)
    {
      
    }

      protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}