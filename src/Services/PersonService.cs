namespace Services;

internal sealed class PersonService : IPersonService
{
    private readonly IRepositoryManager _repositoryManager;

    public PersonService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<PhysicalPersonDto> CreateAsync(CreatePersonDto createPersonDto,
        CancellationToken cancellationToken)
    {
        var city = await _repositoryManager.CityRepository.GetSingleByCondition(x => x.Id == createPersonDto.CityId,
            cancellationToken);
        
        var person = createPersonDto.PersonDtoToPerson();

        _repositoryManager.PersonRepository.Create(person);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        var createdPersonDto = person.PersonToDto(city.Name);

        return createdPersonDto;
    }

    public async Task UpdateAsync(int personId, PersonForUpdateDto updatedPersonDto,
        CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetSingleByCondition(
            x => x.Id == personId, cancellationToken,
            x => x.City,
            x => x.PhoneNumbers,
            x => x.PersonConnections);

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
            x => x.PersonConnections);

        if (person is null)
        {
            throw new PersonNotFoundException(personId);
        }

        var persons = person.MapPersonsDto();

        return persons;
    }

    public async Task DeleteAsync(int personId, CancellationToken cancellationToken)
    {
        var person =
            await _repositoryManager.PersonRepository.GetSingleByCondition(x => x.Id == personId, cancellationToken,
                x => x.PersonConnections, x => x.PhoneNumbers);

        if (person is null)
        {
            throw new PersonNotFoundException(personId);
        }

        _repositoryManager.PersonRepository.Delete(person);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResult<PhysicalPersonDto>> SearchAndPaginate(string searchTerm, int pageNumber, int pageSize)
    {
        var searchResult = _repositoryManager.PersonRepository.Search(searchTerm);
        var personsDto = searchResult.Select(x => x.MapPersonsDto());

        var pagedList = new PagedList<PhysicalPersonDto>(personsDto, pageSize);

        return pagedList.GetPagedResult(pageNumber);
    }

    public async Task<PagedResult<PhysicalPersonDto>> DetailedSearchAndPaginate(string firstName, string lastName,
        string personalNumber, int pageNumber, int pageSize)
    {
        var searchResult = _repositoryManager.PersonRepository.DetailedSearch(firstName, lastName, personalNumber);
        var personsDto = searchResult.Select(x => x.MapPersonsDto());

        var pagedList = new PagedList<PhysicalPersonDto>(personsDto, pageSize);

        return pagedList.GetPagedResult(pageNumber);
    }
}