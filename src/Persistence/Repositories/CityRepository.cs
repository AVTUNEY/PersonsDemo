namespace Persistence.Repositories;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }
}