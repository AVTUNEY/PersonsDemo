namespace Service.Abstractions;

public interface IPersonConnectionService
{
    Task<ConnectedPersonsRelationshipDto> CreateAsync(CreatePersonConnectionDto createPersonConnectionDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(int connectionId, CancellationToken cancellationToken = default);
}