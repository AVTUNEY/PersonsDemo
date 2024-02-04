namespace Persistence.Repositories;

public sealed class PersonRepository : RepositoryBase<PhysicalPerson>, IPersonRepository
{
    public PersonRepository(TbcDemoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<PhysicalPerson>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.PhysicalPersons.ToListAsync(cancellationToken);
    }

    public async Task<PhysicalPerson> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        var res = await _dbContext.PhysicalPersons.Include(x=>x.PhoneNumbers)
                                                                .Include(x=>x.City)
                                                                .Include(r => r.Relatives)
                                                                .ThenInclude(rp => rp.RelatedPerson)
                                                                .FirstOrDefaultAsync(x => x.Id == personId, cancellationToken);
        return res;
    }

    public async Task<IEnumerable<PhysicalPerson>> GetPagedAsync(
        int page, 
        int pageSize,
        string searchTerm,
        CancellationToken cancellationToken = default)
    {
        var query = _dbContext.PhysicalPersons.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(person =>
                EF.Functions.Like(person.FirstName, $"%{searchTerm}%") ||
                EF.Functions.Like(person.LastName, $"%{searchTerm}%") ||
                EF.Functions.Like(person.PersonalNumber, $"%{searchTerm}%"));
        }

        return await query.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}