using Learning.Entities;
using Learning.Entities.Models;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
  private readonly RepositoryContext _context;

  private IBlogRepository _blog;
  private IPostRepository _post;

  public RepositoryManager(RepositoryContext context)
  {
    _context = context;
  }

  public IBlogRepository Blog
  {
    get
    {
      if (_blog == null) _blog = new BlogRepository(_context);

      return _blog;
    }
  }

  public IPostRepository Post
  {
    get
    {
      if (_post == null) _post = new PostRepository(_context);

      return _post;
    }
  }

  public IRepositoryBase<TEntity> Set<TEntity>() where TEntity : ModelBase
  {
    var entityName = typeof(TEntity).Name;
    return (IRepositoryBase<TEntity>)GetType().GetProperty(entityName).GetValue(this, null);
  }

  public Task SaveAsync()
  {
    return _context.SaveChangesAsync();
  }
}