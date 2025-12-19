using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Persistence.Repositories;

public abstract class GenericRepository<TModel, TKey>(DbContext context) : IRepository<TModel, TKey>
    where TModel : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private DbContext Context { get; set; } = context;

    public virtual IQueryable<TModel> AsQueryable()
    {
        var collection = Context.Set<TModel>();
        return collection;
    }

    public virtual async Task<TModel> AddAsync(TModel model)
    {
        var collection = Context.Set<TModel>();
        await collection.AddAsync(model);
        return model;
    }

    public virtual async Task<TModel> UpdateAsync(TKey key, TModel model)
    {
        var trackingEntity = await FindAsync(key);
        if (trackingEntity == null) return model;
        Context.Entry(trackingEntity).State = EntityState.Modified;
        Update(model, trackingEntity);

        return model;
    }

    public virtual async Task<bool> RemoveAsync(TKey key)
    {
        var entity = await FindAsync(key);
        {
            var collection = Context.Set<TModel>();
            if (entity != null) collection.Remove(entity);
            return true;
        }
    }

    public virtual Task<TModel> FindAsync(TKey key)
    {
        return AsQueryable().FirstOrDefaultAsync(e => e.Id.Equals(key));
    }

    protected abstract void Update(TModel requestObject, TModel targetObject);
}