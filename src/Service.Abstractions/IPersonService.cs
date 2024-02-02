using Shared;

namespace Service.Abstractions;

public interface IPersonService
{
    Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default);
}