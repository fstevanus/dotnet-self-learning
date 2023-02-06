using System.Linq.Expressions;
using Learning.Entities;
using Learning.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : ModelBase
{
  private readonly RepositoryContext _repositoryContext;

  public RepositoryBase(RepositoryContext repositoryContext)
  {
    _repositoryContext = repositoryContext;
  }

  public IQueryable<TEntity> FindAll(bool trackChanges)
  {
    return trackChanges
      ? _repositoryContext.Set<TEntity>()
      : _repositoryContext.Set<TEntity>().AsNoTracking();
  }

  public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
  {
    return trackChanges
      ? _repositoryContext.Set<TEntity>().Where(expression)
      : _repositoryContext.Set<TEntity>().Where(expression).AsNoTracking();
  }

  public void Create(TEntity entity)
  {
    _repositoryContext.Set<TEntity>().Add(entity);
  }

  public void Update(TEntity entity)
  {
    _repositoryContext.Set<TEntity>().Update(entity);
  }

  public void Delete(TEntity entity)
  {
    _repositoryContext.Set<TEntity>().Remove(entity);
  }

  public void Delete(IEnumerable<TEntity> entities)
  {
    _repositoryContext.Set<TEntity>().RemoveRange(entities);
  }
}