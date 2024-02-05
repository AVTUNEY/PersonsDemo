namespace Service.Abstractions;

public interface IPersonService
{
    Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default);

    Task<PhysicalPersonDto> CreateAsync(CreatePersonDto createPersonDto,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(int id, PersonForUpdateDto personForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int personId, CancellationToken cancellationToken = default);
    Task<PagedResult<PhysicalPersonDto>> SearchAndPaginate(string searchTerm, int pageNumber, int pageSize);

    Task<PagedResult<PhysicalPersonDto>> DetailedSearchAndPaginate(string firstName, string lastName,
        string personalNumber, int pageNumber, int pageSize);

    ConnectedPersonsResult GetConnectionReport(int targetPersonId,
        ConnectionType connectionType);
}