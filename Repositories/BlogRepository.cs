using Learning.Entities;
using Learning.Entities.Models;

namespace Repositories;

public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
{
  public BlogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  {
  }
}