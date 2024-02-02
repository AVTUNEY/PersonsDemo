namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TbcDemoDbContext _dbContext;

    public UnitOfWork(TbcDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}