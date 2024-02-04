namespace Domain.Repositories;

public interface IPersonRepository : IRepositoryBase<PhysicalPerson>
{
    IEnumerable<PhysicalPerson> Search(string searchTerm);

    IEnumerable<PhysicalPerson> DetailedSearch(string firstName = null, string lastName = null,
        string personalNumber = null);

    IEnumerable<PhysicalPerson> GetConnectedPersonsByType(int targetPersonId,
        ConnectionType connectionType);
}