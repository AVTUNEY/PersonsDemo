using Shared;
using Shared.DTOs;

namespace Service.Abstractions;

public interface IPersonService
{
    Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default);

    Task<PhysicalPersonDto> CreateAsync(PersonForCreationDto personForCreationDto,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(int id, PersonForUpdateDto personForUpdateDto, CancellationToken cancellationToken = default);
}