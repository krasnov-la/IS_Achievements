using System.Linq.Expressions;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class GenericRepository<TEntity>(DbContext db) : IRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> _set = db.Set<TEntity>();

    public void Delete(TEntity entity)
    {
        _set.Remove(entity);
    }

    public void Insert(TEntity entity)
    {
        _set.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _set.Update(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAll<TKey>()
    {
        return await _set.ToListAsync();
    }

    public IQueryable<TEntity> GetQuerable()
    {
        return _set;
    }

    public async Task<TEntity?> GetById<TId>(TId id)
    {
        return await _set.FindAsync(id);
    }
}