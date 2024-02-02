using Domain.Repositories;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(TbcDemoDbContext dbContext)
    {
        
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}