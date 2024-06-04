using System.Linq.Expressions;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> _set;

    public GenericRepository(DbContext db)
    {
        _set = db.Set<TEntity>();
    }

    public void Delete(TEntity entity)
    {
        _set.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> Get<TKey>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TKey>>? orderBy = null)
    {
        IQueryable<TEntity> query = _set;
        if (filter is not null)
            query = query.Where(filter);
        if (orderBy is not null)
            query = query.OrderBy(orderBy);
        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetById<TId>(TId id)
    {
        return await _set.FindAsync(id);
    }

    public void Insert(TEntity entity)
    {
        _set.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _set.Update(entity);
    }
}