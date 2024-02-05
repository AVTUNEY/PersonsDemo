namespace Persistence.Repositories;

public sealed class PersonConnectionRepository : RepositoryBase<PersonConnection>, IPersonConnectionRepository
{
    public PersonConnectionRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }
}