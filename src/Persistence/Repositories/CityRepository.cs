namespace Persistence.Repositories;

public sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }
}