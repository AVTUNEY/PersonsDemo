using Domain.Repositories;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IPersonRepository> _lazyPersonRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(TbcDemoDbContext dbContext)
    {
        _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }

    public IPersonRepository PersonRepository => _lazyPersonRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}