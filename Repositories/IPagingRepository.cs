using Learning.Entities.Models;

namespace Repositories;

public interface IPagingRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : ModelBase
{
}