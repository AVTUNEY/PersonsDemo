using Domain.Entities;

namespace Domain.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<PhysicalPerson>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PhysicalPerson> GetByIdAsync(int personId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PhysicalPerson>> GetPagedAsync(int page, int pageSize,string searchTerm,
        CancellationToken cancellationToken = default);
    Task InsertAsync(PhysicalPerson person, CancellationToken cancellationToken = default);
    void Remove(PhysicalPerson person);
    void Update(PhysicalPerson person);
}