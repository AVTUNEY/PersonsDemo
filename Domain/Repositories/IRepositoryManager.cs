namespace Domain.Repositories;

public interface IRepositoryManager
{
    IPersonRepository PersonRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}