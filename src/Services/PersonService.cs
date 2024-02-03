using Domain.Repositories;
using Service.Abstractions;
using Shared;

namespace Services;

internal sealed class PersonService : IPersonService
{
    private readonly IRepositoryManager _repositoryManager;

    public PersonService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetByIdAsync(personId, cancellationToken);
        var ownersDto = new PhysicalPersonDto()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            BirthDate = person.BirthDate,
            City = person.City.Name,
            Gender = person.Sex.ToString(),
            PersonalNumber = person.PersonalNumber,
            PhoneNumbers = person.PhoneNumbers?.Select(phone => phone.Number).ToList(),
            //ConnectedPersonTypeIds = person.ConnectedPersonTypes.Select(x => x.PhysicalPersonId).ToList()
        };

        return ownersDto;
    }
}