using LifeBalance.Domain.Entities;

namespace LifeBalance.Application.Repositories.Abstractions;

public interface IRepository<TModel, in TKey> where TModel : class, IEntity<TKey>
{
    IQueryable<TModel> AsQueryable();
    Task<TModel> AddAsync(TModel model);
    Task<TModel> UpdateAsync(TKey key, TModel model);
    Task<bool> RemoveAsync(TKey key);
    Task<TModel> FindAsync(TKey key);
}