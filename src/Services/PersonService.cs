using Microsoft.Extensions.Hosting;

namespace Services;

internal sealed class PersonService : IPersonService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IHostEnvironment _environment;
    private const string ImageDirectoryName = "images";
    public PersonService(IRepositoryManager repositoryManager, IHostEnvironment environment)
    {
        _repositoryManager = repositoryManager;
        _environment = environment;
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

    public async Task UpdateAsync(int personId, UpdatePersonDto? updatedPersonDto,
        CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetByIdAsync(personId, cancellationToken);

        if (person == null)
        {
            throw new PersonNotFoundException(personId);
        }

        person.MapPersonToUpdateDto(updatedPersonDto);

        _repositoryManager.PersonRepository.Update(person);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PhysicalPersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        var person = await _repositoryManager.PersonRepository.GetByIdAsync(personId, cancellationToken);

        if (person is null)
        {
            throw new PersonNotFoundException(personId);
        }

        var result = person.MapPersonsDto();

        return result;
    }

    public async Task DeleteAsync(int personId, CancellationToken cancellationToken)
    {
        var person =
            await _repositoryManager.PersonRepository.GetByIdAsync(personId, cancellationToken);

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

    public ConnectedPersonsResult GetConnectionReport(int targetPersonId,
        ConnectionType connectionType)
    {
        var persons =
            _repositoryManager.PersonRepository.GetConnectedPersonsByType(targetPersonId, connectionType);

        var connectedPersonsList = persons
            .Select(p => new ConnectedPersonInfoDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName
            })
            .ToList();

        var result = new ConnectedPersonsResult
        {
            Count = connectedPersonsList.Count,
            ConnectionType = connectionType.ToString(),
            ConnectedPersons = connectedPersonsList
        };

        return result;
    }

    public async Task UploadPhoto(int personId, UploadPersonPhoto photo, CancellationToken token)
    {
        if (photo.File.Length > 0)
        {
            var uploadsFolder = Path.Combine(_environment.ContentRootPath, ImageDirectoryName);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid() + "_" + photo.Name;
            var filePath = Path.Combine(ImageDirectoryName, uniqueFileName);
            var fileExtension = Path.GetExtension(photo.File.FileName);
            var fullPath = Path.Combine(uploadsFolder, uniqueFileName) + fileExtension;
            var fileWithExtension = filePath + fileExtension;

            await using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await photo.File.CopyToAsync(fileStream, token);
            }

            var person = await _repositoryManager.PersonRepository.GetSingleByCondition(
                x => x.Id == personId, token);
            if (person == null)
            {
                throw new PersonNotFoundException(personId);
            }

            person.ImagePath = fileWithExtension;
            
            _repositoryManager.PersonRepository.Update(person);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(token);
        }
    }
}