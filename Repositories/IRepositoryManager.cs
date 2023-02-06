using Learning.Entities.Models;

namespace Repositories;

public interface IRepositoryManager
{
  IBlogRepository Blog { get; }
  IPostRepository Post { get; }
  IRepositoryBase<TEntity> Set<TEntity>() where TEntity : ModelBase;

  Task SaveAsync();
}