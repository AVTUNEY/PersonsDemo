namespace Domain.Repositories;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

    Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, CancellationToken token,
        params Expression<Func<T, object>>[] includes);

    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}