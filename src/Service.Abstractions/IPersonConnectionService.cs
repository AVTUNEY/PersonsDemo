namespace Service.Abstractions;

public interface IPersonConnectionService
{
    Task<ConnectedPersonsDto> CreateAsync(CreatePersonConnectionDto createPersonConnectionDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(int connectionId, CancellationToken cancellationToken = default);
}