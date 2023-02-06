using System.Reflection;
using Learning.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Entities;

public class RepositoryContext : DbContext
{
  public RepositoryContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Post> Posts { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}