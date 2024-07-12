using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
namespace Services;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll<TKey>();

    Task<TEntity?> GetById<TId>(TId id);

    IQueryable<TEntity> GetQuerable();

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}