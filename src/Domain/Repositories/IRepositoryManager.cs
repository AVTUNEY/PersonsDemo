namespace Domain.Repositories;

public interface IRepositoryManager
{
    IPersonRepository PersonRepository { get; }
    IRelativeRepository RelativeRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}