using Learning.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learning.Entities.Configurations;

public class BlogConfiguration
{
  public void Configure(EntityTypeBuilder<Blog> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id).ValueGeneratedOnAdd();
    builder.Property(e => e.Url).IsRequired();
  } 
}