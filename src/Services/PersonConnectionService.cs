namespace Services;

public class PersonConnectionService : IPersonConnectionService
{
    private readonly IRepositoryManager _repositoryManager;

    public PersonConnectionService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<ConnectedPersonsDto> CreateAsync(CreatePersonConnectionDto createPersonConnectionDto,
        CancellationToken cancellationToken = default)
    {
        var personConnection = new PersonConnection()
        {
            PersonId = createPersonConnectionDto.PersonId,
            ConnectedPersonId = createPersonConnectionDto.ConnectedPersonId,
            ConnectionType = createPersonConnectionDto.Type
        };

        _repositoryManager.PersonConnectionRepository.Create(personConnection);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        var createdRelation =
            new ConnectedPersonsDto(personConnection.PersonId, personConnection.ConnectedPersonId,
                personConnection.ConnectionType);

        return createdRelation;
    }

    public async Task DeleteAsync(int connectionId, CancellationToken cancellationToken = default)
    {
        var connection =
            await _repositoryManager.PersonConnectionRepository.GetSingleByCondition(x => x.Id == connectionId,
                cancellationToken);

        if (connection is null)
        {
            throw new PersonConnectionNotFoundException(connectionId);
        }

        _repositoryManager.PersonConnectionRepository.Delete(connection);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}