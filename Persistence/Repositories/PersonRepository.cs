using Domain.Repositories;

namespace Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    public PersonRepository(TbcDemoDbContext dbContext)
    {
        
    }
}