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
        var result = await _dbContext.PhysicalPersons.Include(x => x.PhoneNumbers)
            .Include(x => x.City)
            .Include(r => r.PersonConnections)
            .FirstOrDefaultAsync(x => x.Id == personId, cancellationToken);

        return result;
    }

    public IEnumerable<PhysicalPerson> Search(string searchTerm)
    {
        var result = _dbContext.PhysicalPersons
            .Include(x => x.PhoneNumbers)
            .Include(x => x.PersonConnections)
            .Include(x => x.City).Where(p =>
                p.FirstName.Contains(searchTerm) ||
                p.LastName.Contains(searchTerm) ||
                p.PersonalNumber.Contains(searchTerm)
            ).ToList();

        return result;
    }

    public IEnumerable<PhysicalPerson> DetailedSearch(string firstName = null, string lastName = null,
        string personalNumber = null)
    {
        var result = _dbContext.PhysicalPersons.Include(x => x.PhoneNumbers)
            .Include(x => x.PersonConnections)
            .Include(x => x.City)
            .Where(p =>
                (firstName == null || p.FirstName == firstName) &&
                (lastName == null || p.LastName == lastName) &&
                (personalNumber == null || p.PersonalNumber == personalNumber)
            );

        return result;
    }

    public IEnumerable<PhysicalPerson> GetConnectedPersonsByType(int targetPersonId,
        ConnectionType connectionType)
    {
        var connectedPersonsQuery = _dbContext.PersonConnections
            .Where(r => (r.PersonId == targetPersonId || r.ConnectedPersonId == targetPersonId) &&
                        r.ConnectionType == connectionType)
            .Select(r => r.PersonId == targetPersonId ? r.ConnectedPerson : r.Person);

        var connectedPersonsList = connectedPersonsQuery.ToList();

        return connectedPersonsList;
    }
}