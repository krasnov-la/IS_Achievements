using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
namespace Services;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> Get<TKey>(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, TKey>>? orderBy = null
    );

    Task<TEntity?> GetById<TId>(TId id);

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}