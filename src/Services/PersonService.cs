namespace Services;

internal sealed class PersonService : IPersonService
{
    private readonly IRepositoryManager _repositoryManager;

    public PersonService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<PhysicalPersonDto> CreateAsync(PersonForCreationDto personForCreationDto,
        CancellationToken cancellationToken)
    {
        var person = personForCreationDto.PersonDtoToPerson();

        _repositoryManager.PersonRepository.Create(person);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        var createdPersonDto = person.PersonToDto();

        return createdPersonDto;
    }

    public async Task UpdateAsync(int personId, PersonForUpdateDto updatedPersonDto,
        CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetSingleByCondition(
            x => x.Id == personId, cancellationToken,
            x => x.City,
            x => x.PhoneNumbers,
            x => x.Relatives);

        if (person == null)
        {
            throw new PersonNotFoundException(personId);
        }

        person.UpdateFromDto(updatedPersonDto);

        _repositoryManager.PersonRepository.Update(person);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetSingleByCondition(
            x => x.Id == personId, cancellationToken,
            x => x.City,
            x => x.PhoneNumbers,
            x => x.Relatives);

        if (person is null)
        {
            throw new PersonNotFoundException(personId);
        }
        
        var persons = person.PersonToDto();

        return persons;
    }
}