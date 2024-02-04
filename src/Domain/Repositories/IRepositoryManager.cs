namespace Domain.Repositories;

public interface IRepositoryManager
{
    IPersonRepository PersonRepository { get; }
    IPersonConnectionRepository PersonConnectionRepository { get; }
    ICityRepository CityRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}