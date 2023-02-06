using Learning.Entities;
using Learning.Entities.Models;

namespace Repositories;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
  public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  {
  }
}