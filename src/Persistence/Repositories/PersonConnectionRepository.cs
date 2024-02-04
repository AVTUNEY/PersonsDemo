namespace Persistence.Repositories;

public class PersonConnectionRepository : RepositoryBase<PersonConnection>, IPersonConnectionRepository
{
    public PersonConnectionRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }
}