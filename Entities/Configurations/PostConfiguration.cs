using Learning.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learning.Entities.Configurations;

public class PostConfiguration
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id).ValueGeneratedOnAdd();
    builder.Property(e => e.Content);
    builder.Property(e => e.Title).IsRequired();
    builder.HasOne(e => e.Blog)
      .WithMany(b => b.Posts)
      .HasForeignKey(e => e.BlogId);
  }
}