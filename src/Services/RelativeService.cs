using Domain.Entities;

namespace Services;

public class RelativeService : IRelativeService
{
    private readonly IRepositoryManager _repositoryManager;

    public RelativeService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<RelativeDto> CreateAsync(RelativeForCreationDto personForCreationDto,
        CancellationToken cancellationToken = default)
    {
        var relative = new Relative()
        {
            PersonId = personForCreationDto.PersonId,
            RelatedPersonId = personForCreationDto.RelativeId,
            RelationshipType = personForCreationDto.Type
        };

        _repositoryManager.RelativeRepository.Create(relative);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        var createdRelation = new RelativeDto()
        {
            RelatedPersonId = relative.RelatedPersonId,
            RelationshipType = relative.RelationshipType
        };

        return createdRelation;
    }

    public async Task DeleteAsync(int relativeId, CancellationToken cancellationToken = default)
    {
        var relative =
            await _repositoryManager.RelativeRepository.GetSingleByCondition(x => x.Id == relativeId,
                cancellationToken);

        if (relative is null)
        {
            throw new PersonNotFoundException(relativeId);
        }

        _repositoryManager.RelativeRepository.Delete(relative);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}