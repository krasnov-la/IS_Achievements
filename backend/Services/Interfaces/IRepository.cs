namespace Services;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll<TKey>();

    Task<TEntity?> GetById<TId>(TId id);

    IQueryable<TEntity> GetQueryable();

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}