namespace Persistence.Repositories;

public class RelativeRepository : RepositoryBase<Relative>, IRelativeRepository
{
    public RelativeRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }
}