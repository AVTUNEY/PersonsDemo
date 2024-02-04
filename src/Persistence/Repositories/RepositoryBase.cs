namespace Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected TbcDemoDbContext _dbContext { get; }

    protected RepositoryBase(TbcDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> GetAll() => _dbContext.Set<T>().AsNoTracking();

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
        _dbContext.Set<T>().Where(expression).AsNoTracking();

    public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, CancellationToken token,
        params Expression<Func<T, object>>[] includes)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(expression, token);
    }

    public void Create(T entity) => _dbContext.Set<T>().Add(entity);
    public void Update(T entity) => _dbContext.Set<T>().Update(entity);
    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
}