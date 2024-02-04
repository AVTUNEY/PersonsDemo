namespace Service.Abstractions;

public interface IRelativeService
{
    Task<RelativeDto> CreateAsync(RelativeForCreationDto personForCreationDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(int personId, CancellationToken cancellationToken = default);
}